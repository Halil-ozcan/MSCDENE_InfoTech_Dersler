using System;
using System.IO.Compression;
using System.Linq.Expressions;
using AutoMapper;
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
                return ResponseDTO<ProductDTO>.Fail("En az bir kategori seçilmelidir.", StatusCodes.Status400BadRequest);
            }
            foreach (var categoryId in productCreateDTO.CategoryIds)
            {
                var isCategoryExists = await _categoryRepository.ExistsAsync(x => x.Id == categoryId);
                if (!isCategoryExists) return ResponseDTO<ProductDTO>.Fail($"{categoryId} id'li Kategori veri tabanında bulunamadığı için kayıt gerçekleştirilemedi.", StatusCodes.Status400BadRequest);
            }
            var product = _mapper.Map<Product>(productCreateDTO);
            // Resim Operasyonu
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
            // Resim operasyonu bitti
            await _productRepository.AddAsync(product);
            var result = await _unitOfWork.SaveAsync();
            if (result != 1)
            {
                _imageService.DeleteImage(tempImageUrl);
                return ResponseDTO<ProductDTO>.Fail("Beklenmedik bir sorun oluştu", StatusCodes.Status500InternalServerError);
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
                _imageService.DeleteImage(tempImageUrl);
                return ResponseDTO<ProductDTO>.Fail("Beklenmedik bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return ResponseDTO<ProductDTO>.Success(productDTO, "Ürün Başarı ile eklendi", StatusCodes.Status201Created);


        }
        catch (Exception ex)
        {
            return ResponseDTO<ProductDTO>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<int>> CountAsync(bool? isDeleted = null, int? categoryId = null)
    {
        try
        {
            Expression<Func<Product, bool>> predicate = x => true;
            if (isDeleted.HasValue)//hasvalue bir değere(true/false)sahipse demek yani ayrı ayrı true false için if yapmaya gerek kalmaz.
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
            return ResponseDTO<int>.Success(count, "İşelem Başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<int>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isDeleted = null, bool includeCategories = false, int? categoryId = null)
    {
        try
        {
            bool includeDeleted = true;
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

            var includeList = new List<Func<IQueryable<Product>, IQueryable<Product>>>();
            if (categoryId.HasValue && includeCategories)
            {
                includeList.Add(query => query.Include(x => x.ProductCategories));
            }
            if (includeCategories)
            {
                includeList.Add(query => query.Include(x => x.ProductCategories).ThenInclude(x => x.Category));
            }
            var products = await _productRepository.GetAllAsync(
                    predicate: predicate,
                    includeDeleted: includeDeleted,
                    includes: includeList.ToArray()
            );
            if (!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç Ürün Bulunamadı", StatusCodes.Status404NotFound);
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
           
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, "İşlem Başarıyla Tamamlandı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<IEnumerable<ProductDTO>>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllHomePageAsync()
    {
        try
        {
            var products = await _productRepository.GetAllAsync(predicate: x => x.IsHome);
            if (!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç ana sayfa ürünü Bulunamadı", StatusCodes.Status404NotFound);
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
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, "İşlem Başarıyla Tamamlandı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<IEnumerable<ProductDTO>>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
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
                includes: query => query.Include(x => x.ProductCategories).ThenInclude(x => x.Category!));
            }
            else
            {
                product = await _productRepository.GetAsync(predicate: x => x.Id == id);
            }

            if (product is null)
            {
                return ResponseDTO<ProductDTO>.Fail("Ürün Bulunamadı", StatusCodes.Status404NotFound);
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
            return ResponseDTO<ProductDTO>.Success(productDTO, "İşlem Başarıyla Tamamlandı", StatusCodes.Status200OK);

        }
        catch (Exception ex)
        {
            return ResponseDTO<ProductDTO>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
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
                return ResponseDTO<NoContentDTO>.Fail("Ürün Bulunamadığı için işlem başarısız oldu", StatusCodes.Status404NotFound);
            }
            _productRepository.Delete(product);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Sileme işlemi sırasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            _imageService.DeleteImage(product.ImageUrl!);
            return ResponseDTO<NoContentDTO>.Success("İşlem Başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
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
                return ResponseDTO<NoContentDTO>.Fail("Ürün Bulunamadığı için işlem başarısız oldu", StatusCodes.Status404NotFound);
            }
            product.IsDeleted = !product.IsDeleted;
            if(product.IsDeleted) product.IsHome = false;
            product.UpdatedAt = DateTime.UtcNow;
            _productRepository.Update(product);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Sileme işlemi sırasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("İşlem Başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> SoftDeleteByCategoryAsync(int categoryId)
    {

        try
        {
            var products = await _productRepository.GetAllAsync(
                predicate: x => x.ProductCategories.Any(x => x.CategoryId == categoryId)
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
                return ResponseDTO<NoContentDTO>.Fail("Sileme işlemi sırasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("İşlem Başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
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
                return ResponseDTO<NoContentDTO>.Fail("Ürün bulunamadığı için güncelleme yapılamadı.", StatusCodes.Status404NotFound);
            }
            if (productUpdateDTO.CategoryIds.Count == 0)
            {
                return ResponseDTO<NoContentDTO>.Fail("Kategori seçilemediği için güncelleme yapılamadı.", StatusCodes.Status400BadRequest);
            }
            foreach (var categoryId in productUpdateDTO.CategoryIds)
            {
                var isCategoryExists = await _categoryRepository.ExistsAsync(x => x.Id == categoryId);
                if (!isCategoryExists) return ResponseDTO<NoContentDTO>.Fail($"{categoryId} id'li Kategori veri tabanında bulunamadığı için kayıt gerçekleştirilemedi.", StatusCodes.Status400BadRequest);
            }
            var oldImageUrl = product.ImageUrl;
            if (productUpdateDTO.Image is not null)
            {
                var imageResponse = await _imageService.UploadImageAsync(productUpdateDTO.Image, "Products");
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
            return ResponseDTO<NoContentDTO>.Success("İşlem Başarılı", StatusCodes.Status200OK);

        }
        catch (Exception ex)
        {
            _imageService.DeleteImage(tempImageUrl);
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> UpdateIsHomeAsync(int id)
    {
        try
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("Ürün Bulunamadığı için işlem başarısız oldu", StatusCodes.Status404NotFound);
            }
            product.IsHome = !product.IsHome;
            product.UpdatedAt = DateTime.UtcNow;
            _productRepository.Update(product);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Ana sayfa ürünü yapma işlemi esnasında bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("İşlem Başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}
