using System;
using System.Linq.Expressions;
using AutoMapper;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;

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
                if(isDeleted.HasValue)
                    predicate = x => x.IsDeleted==isDeleted && x.ProductCategories.Any(x => x.CategoryId == categoryId);
                else
                    predicate = x => x.ProductCategories.Any(x=>x.CategoryId == categoryId);
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

    public Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isDeleted = false, bool includeCategories = false, int? categoryId = null)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllHomePageAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<ProductDTO>> GetAsync(int id, bool includeCategories = false)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> HardDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> SoftDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> SoftDeleteByCategoryAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> UpdateAsync(ProductUpdateDTO productUpdateDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> UpdateIsHomeAsync(int id)
    {
        throw new NotImplementedException();
    }
}
