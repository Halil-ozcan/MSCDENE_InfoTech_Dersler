using System;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using AutoMapper;
using Azure;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ECommerceApp.Backend.Business.Concrete;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _productRepository = _unitOfWork.GetRepository<Product>();
        _categoryRepository = _unitOfWork.GetRepository<Category>();
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<ResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO productCreateDTO)
    {
        var tempImageUrl = string.Empty;
        try
        {
            // Kategori kontrolü
            if (productCreateDTO.CategoryIds.Count == 0)
            {
                return ResponseDTO<ProductDTO>.Fail("En az bir kategori seçilmelidir", StatusCodes.Status400BadRequest);
            }
            // categoryIds=[5,7,12]
            // categoryIds içindeki kategori id'lerinin gerçekten var olup olmadığı kontrol ediliyor.
            foreach (var categoryId in productCreateDTO.CategoryIds)
            {
                var isCategoryExists = await _categoryRepository.ExistsAsync(x => x.Id == categoryId);
                if (!isCategoryExists) return ResponseDTO<ProductDTO>.Fail($"{categoryId} id'li Kategori veri tabanında bulunamadığı için kayıt gerçekleştirilemedi", StatusCodes.Status400BadRequest);
            }
            var product = _mapper.Map<Product>(productCreateDTO);
            // Resim operasyonu
            if (productCreateDTO.Image is null)
            {
                return ResponseDTO<ProductDTO>.Fail("Ürün resmi boş olamaz!", StatusCodes.Status400BadRequest);
            }
            var imageResponse = await _imageService.UploadImageAsync(productCreateDTO.Image, "products");
            if (!imageResponse.IsSuccessful)
            {
                return ResponseDTO<ProductDTO>.Fail(imageResponse.Message, imageResponse.StatusCode);
            }
            product.ImageUrl = tempImageUrl = imageResponse.Data;
            await _productRepository.AddAsync(product);
            var result = await _unitOfWork.SaveAsync();
            if (result != 1)
            {
                _imageService.DeleteImage(tempImageUrl);
                return ResponseDTO<ProductDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            product.ProductCategories =
                productCreateDTO
                    .CategoryIds
                    .Select(x => new ProductCategory(product.Id, x))
                    .ToList();
            _productRepository.Update(product);
            var resultUpdate = await _unitOfWork.SaveAsync();
            if (resultUpdate == 0)
            {
                return ResponseDTO<ProductDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            var productDTO = _mapper.Map<ProductDTO>(product);//Categories içindeki Category'ler null geliyor, düzeltilecek.

            return ResponseDTO<ProductDTO>.Success(productDTO, "Ürün başarıyla eklendi", StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return ResponseDTO<ProductDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<int>> CountAsync(bool? isDeleted = null, int? categoryId = null)
    {
        try
        {
            Expression<Func<Product, bool>> predicate = x => true;
            if (isDeleted.HasValue)
            {
                predicate = x => x.IsDeleted == isDeleted;
            }
            if (categoryId.HasValue)
            {
                if (isDeleted.HasValue)
                    predicate = x => x.IsDeleted == isDeleted && x.ProductCategories.Any(x => x.CategoryId == categoryId);
                else
                    predicate = x => x.ProductCategories.Any(x => x.CategoryId == categoryId);
            }
            var includeDeleted = isDeleted != false;
            var count = await _productRepository.CountAsync(
                predicate: predicate,
                includeDeleted: includeDeleted
            );
            return ResponseDTO<int>.Success(count, "İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<int>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }


    // 1) Silinmiş, kategorileri dahil edilen ürünler
    // 2) Silinmiş, kategorileri dahil edilmeyen ürünler
    // 3) Silinmemiş, kategorileri dahil edilen ürünler
    // 4) Silinmemiş, kategorileri dahil edilmeyen ürünler
    // 5) Silinmemiş ya da silinmemiş fark etmeksizin, kategorileri dahil edilen ürünler
    // 6) Silinmemiş ya da silinmemiş fark etmeksizin, kategorileri dahil edilmeyen ürünler
    // Belirli bir kategorideki ÜRÜNLER: 
    // 1) Silinmiş, kategorileri dahil edilen ürünler
    // 2) Silinmiş, kategorileri dahil edilmeyen ürünler
    // 3) Silinmemiş, kategorileri dahil edilen ürünler
    // 4) Silinmemiş, kategorileri dahil edilmeyen ürünler
    // 5) Silinmemiş ya da silinmemiş fark etmeksizin, kategorileri dahil edilen ürünler
    // 6) Silinmemiş ya da silinmemiş fark etmeksizin, kategorileri dahil edilmeyen ürünler
    public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isDeleted = null, bool includeCategories = false, int? categoryId = null)
    {
        try
        {
            bool includeDeleted = true;
            // predicate'i hazırlıyoruz
            Expression<Func<Product, bool>> predicate = x => true;
            if (isDeleted.HasValue)
            {
                predicate = x => x.IsDeleted == isDeleted;
                if (isDeleted == false) includeDeleted = false;
            }
            if (categoryId.HasValue)
            {
                if (isDeleted.HasValue)
                    predicate = x => x.IsDeleted == isDeleted && x.ProductCategories.Any(x => x.CategoryId == categoryId);
                else
                    predicate = x => x.ProductCategories.Any(x => x.CategoryId == categoryId);
            }

            // includes'u hazırlıyoruz
            var includesList = new List<Func<IQueryable<Product>, IQueryable<Product>>>();
            // categoryId null değilse
            if (categoryId.HasValue && includeCategories)
            {
                includesList.Add(query => query.Include(x => x.ProductCategories));
            }
            // includeCategories true ise 
            if (includeCategories)
            {
                includesList.Add(query => query.Include(x => x.ProductCategories).ThenInclude(y => y.Category));
            }
            // Repository'den verileri iste
            var products = await _productRepository.GetAllAsync(
                predicate: predicate,
                includeDeleted: includeDeleted,
                includes: includesList.ToArray()
            );

            if (!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç ürün bulunamadı", StatusCodes.Status404NotFound);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            foreach (var productDTO in productDTOs)
            {
                if (!_imageService.ImageExists(productDTO.ImageUrl))
                {
                    productDTO.ImageUrl = _imageService.GetDefaultImage("products");
                }
                foreach (var categoryDTO in productDTO.Categories)
                {
                    if (!_imageService.ImageExists(categoryDTO.ImageUrl!))
                    {
                        categoryDTO.ImageUrl = _imageService.GetDefaultImage("categories");
                    }
                }
            }

            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, "İşlem başarıyla tamamlandı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<IEnumerable<ProductDTO>>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    // Ana sayfada görüntülenecek silinmemiş tüm ürünler (kategorisiz)
    public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllHomePageAsync()
    {
        try
        {
            var products = await _productRepository.GetAllAsync(predicate: x => x.IsHome);
            if (!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç ana sayfa ürünü bulunamadı", StatusCodes.Status404NotFound);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            foreach (var productDTO in productDTOs)
            {
                if (!_imageService.ImageExists(productDTO.ImageUrl))
                {
                    productDTO.ImageUrl = _imageService.GetDefaultImage("products");
                }
                foreach (var categoryDTO in productDTO.Categories)
                {
                    if (!_imageService.ImageExists(categoryDTO.ImageUrl!))
                    {
                        categoryDTO.ImageUrl = _imageService.GetDefaultImage("categories");
                    }
                }
            }

            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, "İşlem başarıyla tamamlandı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<IEnumerable<ProductDTO>>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<ProductDTO>> GetAsync(int id, bool includeCategories = false)
    {
        try
        {
            Product product;
            if (includeCategories == true)
            {
                product = await _productRepository.GetAsync(
                    predicate: x => x.Id == id,
                    includes: query => query
                    .Include(x => x.ProductCategories)
                    .ThenInclude(y => y.Category!));
            }
            else
            {
                product = await _productRepository.GetAsync(predicate: x => x.Id == id);
            }

            if (product is null)
            {
                return ResponseDTO<ProductDTO>.Fail("Ürün bulunamadı", StatusCodes.Status404NotFound);
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            if (!_imageService.ImageExists(productDTO.ImageUrl))
            {
                productDTO.ImageUrl = _imageService.GetDefaultImage("products");
            }

            foreach (var categoryDTO in productDTO.Categories)
            {
                if (!_imageService.ImageExists(categoryDTO.ImageUrl!))
                {
                    categoryDTO.ImageUrl = _imageService.GetDefaultImage("categories");
                }
            }

            return ResponseDTO<ProductDTO>.Success(productDTO, "İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<ProductDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> HardDeleteAsync(int id)
    {
        try
        {
            var product = await _productRepository.GetAsync(
                predicate: x => x.Id == id,
                includeDeleted: true
            );
            if (product is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("Ürün bulunamadığı için işlem başarısız oldu", StatusCodes.Status404NotFound);
            }
            _productRepository.Delete(product);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Silme işlemi sırasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            _imageService.DeleteImage(product.ImageUrl!);
            return ResponseDTO<NoContentDTO>.Success("İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> SoftDeleteAsync(int id)
    {
        try
        {
            var product = await _productRepository.GetAsync(
                predicate: x => x.Id == id,
                includeDeleted: true
            );
            if (product is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("Ürün bulunamadığı için işlem başarısız oldu", StatusCodes.Status404NotFound);
            }
            product.IsDeleted = !product.IsDeleted;
            // Eğer ürün çöpe atıldıysa(IsDeleted'i false yapıldıysa) bu durumda IsHome'unu da false yapmalıyız.
            if (product.IsDeleted) product.IsHome = false;
            product.UpdatedAt = DateTime.UtcNow;
            _productRepository.Update(product);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Silme işlemi sırasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }

            return ResponseDTO<NoContentDTO>.Success("İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> SoftDeleteByCategoryAsync(int categoryId)
    {
        try
        {
            var products = await _productRepository.GetAllAsync(
                predicate: x => x.ProductCategories.Any(y => y.CategoryId == categoryId)
            );
            foreach (var product in products)
            {
                product.IsDeleted = true;
                product.UpdatedAt = DateTime.UtcNow;
            }
            _productRepository.BatchUpdate(products);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Silme işlemi sırasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> UpdateAsync(ProductUpdateDTO productUpdateDTO)
    {
        var tempImageUrl = string.Empty;
        try
        {
            var product = await _productRepository.GetAsync(
                predicate: x => x.Id == productUpdateDTO.Id,
                includes: query => query.Include(x => x.ProductCategories)
            );
            if (product is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("Ürün bulunamadığı için güncelleme yapılamadı", StatusCodes.Status404NotFound);
            }
            if (productUpdateDTO.CategoryIds.Count == 0)
            {
                return ResponseDTO<NoContentDTO>.Fail("Kategori seçilmediği için güncelleme yapılamadı", StatusCodes.Status400BadRequest);
            }

            foreach (var categoryId in productUpdateDTO.CategoryIds)
            {
                var isCategoryExists = await _categoryRepository.ExistsAsync(x => x.Id == categoryId);
                if (!isCategoryExists) return ResponseDTO<NoContentDTO>.Fail($"{categoryId} id'li kategori veri tabanında bulunamadığı için güncelleme gerçekleştirilemedi", StatusCodes.Status400BadRequest);
            }
            var oldImageUrl = product.ImageUrl;
            if (productUpdateDTO.Image is not null)
            {
                var imageResponse = await _imageService.UploadImageAsync(productUpdateDTO.Image, "products");
                if (!imageResponse.IsSuccessful)
                {
                    return ResponseDTO<NoContentDTO>.Fail(imageResponse.Message, imageResponse.StatusCode);
                }
                product.ImageUrl = tempImageUrl = imageResponse.Data;
            }
            _mapper.Map(productUpdateDTO, product);
            product.ProductCategories.Clear();
            product.ProductCategories = productUpdateDTO
                .CategoryIds
                .Select(x => new ProductCategory(product.Id, x)).ToList();
            product.UpdatedAt = DateTime.UtcNow;
            _productRepository.Update(product);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Güncelleme sırasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            if (productUpdateDTO.Image is not null) _imageService.DeleteImage(oldImageUrl!);
            return ResponseDTO<NoContentDTO>.Success("İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            _imageService.DeleteImage(tempImageUrl);
            return ResponseDTO<NoContentDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> UpdateIsHomeAsync(int id)
    {
        try
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("Ürün bulunamadığı için işlem başarısız oldu", StatusCodes.Status404NotFound);
            }
            product.IsHome = !product.IsHome;
            product.UpdatedAt = DateTime.UtcNow;
            _productRepository.Update(product);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Ana sayfa ürünü yapma işlemi sırasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }

            return ResponseDTO<NoContentDTO>.Success("İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}