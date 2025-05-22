using System;
using System.Linq.Expressions;
using AutoMapper;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Backend.Business.Concrete;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = _unitOfWork.GetRepository<Category>();
        _productCategoryRepository = _unitOfWork.GetRepository<ProductCategory>();
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO)
    {
        var tempImageUrl = string.Empty;
        try
        {
            var isExists = await _categoryRepository.ExistsAsync(x => x.Name!.ToLower() == categoryCreateDTO.Name.ToLower());
            if (isExists)//Eğer bu isimde bir kategori varsa
            {
                return ResponseDTO<CategoryDTO>.Fail($"{categoryCreateDTO.Name} adlı kategori mevcut olduğu için kayıt yapılamadı!", StatusCodes.Status400BadRequest);
            }
            var category = _mapper.Map<Category>(categoryCreateDTO);
            // Resim operasyonu
            if (categoryCreateDTO.Image is null)
            {
                return ResponseDTO<CategoryDTO>.Fail("Kategori resmi boş olamaz!", StatusCodes.Status400BadRequest);
            }
            var imageResponse = await _imageService.UploadImageAsync(categoryCreateDTO.Image, "categories");
            if (!imageResponse.IsSuccessful)
            {
                return ResponseDTO<CategoryDTO>.Fail(imageResponse.Message, imageResponse.StatusCode);
            }
            category.ImageUrl = tempImageUrl = imageResponse.Data;
            // Resim operasyonu bitti
            await _categoryRepository.AddAsync(category);
            var result = await _unitOfWork.SaveAsync();
            if (result != 1)
            {
                _imageService.DeleteImage(tempImageUrl);
                return ResponseDTO<CategoryDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, "Kategori başarıyla kaydedildi", StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            _imageService.DeleteImage(tempImageUrl);
            return ResponseDTO<CategoryDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<int>> CountAsync(bool? isDeleted = false)
    {
        try
        {
            int count;
            if (isDeleted is null)
            {
                count = await _categoryRepository.CountAsync(includeDeleted: true);
            }
            else
            {
                count = await _categoryRepository.CountAsync(
                    predicate: x => x.IsDeleted == isDeleted,
                    includeDeleted: (bool)isDeleted
                );
            }
            return ResponseDTO<int>.Success(count, "Kategori adedi başarıyla hesaplandı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<int>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync(bool? isDeleted)
    {
        try
        {
            bool includeDeleted = true;
            Expression<Func<Category, bool>> myPredicate = x => true;
            if (isDeleted.HasValue)
            {
                myPredicate = x => x.IsDeleted == isDeleted.Value;
                if (isDeleted == false) includeDeleted = false;
            }
            var categories = await _categoryRepository.GetAllAsync(predicate: myPredicate, includeDeleted: includeDeleted);
            if (!categories.Any())
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Hiç kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            // Resim kontrolü 
            foreach (var categoryDTO in categoryDTOs)
            {
                if (!_imageService.ImageExists(categoryDTO.ImageUrl!))
                {
                    categoryDTO.ImageUrl = _imageService.GetDefaultImage("categories");
                }
            }
            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(categoryDTOs, "Kategoriler başarıyla gönderildi", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<IEnumerable<CategoryDTO>>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<CategoryDTO>> GetAsync(int id)
    {
        try
        {
            Category category = await _categoryRepository.GetAsync(id);
            if (category is null)
            {
                return ResponseDTO<CategoryDTO>.Fail($"{id} id'li kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
            // Resim kontrolü
            var isImageExists = _imageService.ImageExists(category.ImageUrl!);
            if (!isImageExists)
            {
                categoryDTO.ImageUrl = _imageService.GetDefaultImage("categories");
            }
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, "Kategori başarıyla gönderildi", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<CategoryDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> HardDeleteAsync(int id)
    {
        try
        {
            var category = await _categoryRepository.GetAsync(
                predicate: x => x.Id == id,
                includeDeleted: true
            );
            if (category is null)
            {
                return ResponseDTO<NoContentDTO>.Fail($"{id} id'li kategori bulunamadığı için silme işlemi gerçekleştirilemedi", StatusCodes.Status404NotFound);
            }
            // Bu kategoride ürün var mı?
            var hasProducts = await _productCategoryRepository.ExistsAsync(x => x.CategoryId == id);
            if (hasProducts)
            {
                return ResponseDTO<NoContentDTO>.Fail("Bu kategoride ürünler mevcut olduğu için silme işlemi gerçekleştirilemedi", StatusCodes.Status400BadRequest);
            }
            _categoryRepository.Delete(category);
            var result = await _unitOfWork.SaveAsync();
            if (result != 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            _imageService.DeleteImage(category.ImageUrl!);
            return ResponseDTO<NoContentDTO>.Success("Kategori başarıyla silindi", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> SoftDeleteAsync(int id)
    {
        try
        {
            var category = await _categoryRepository.GetAsync(
                predicate: x => x.Id == id,
                includeDeleted: true
            );
            if (category is null)
            {
                return ResponseDTO<NoContentDTO>.Fail($"{id} id'li kategori bulunamadığı için silme işlemi gerçekleştirilemedi", StatusCodes.Status404NotFound);
            }
            // Bu kategoride ürün var mı?
            var hasProducts = await _productCategoryRepository.ExistsAsync(x => x.CategoryId == id);
            if (hasProducts)
            {
                return ResponseDTO<NoContentDTO>.Fail("Bu kategoride ürünler mevcut olduğu için silme işlemi gerçekleştirilemedi", StatusCodes.Status400BadRequest);
            }
            category.IsDeleted = !category.IsDeleted;// true ise false; false ise true yap
            category.DeletedAt = DateTimeOffset.UtcNow;
            _categoryRepository.Update(category);
            var result = await _unitOfWork.SaveAsync();
            if (result != 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success(category.IsDeleted ? "Kategori başarıyla çöp kutusuna gönderildi" : "Kategori başarıyla çöp kutusundan çıkarıldı!", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
    {
        var tempImageUrl = string.Empty;
        try
        {
            var category = await _categoryRepository.GetAsync(categoryUpdateDTO.Id);
            if (category is null)
            {
                return ResponseDTO<NoContentDTO>.Fail($"{categoryUpdateDTO.Id} id'li kategori bulunamadığı için güncelleme işlemi gerçekleştirilemedi", StatusCodes.Status404NotFound);
            }
            var oldImageUrl = category.ImageUrl;
            // resim operayonu
            if (categoryUpdateDTO.Image is not null)
            {
                var imageResponse = await _imageService.UploadImageAsync(categoryUpdateDTO.Image, "categories");
                if (!imageResponse.IsSuccessful)
                {
                    return ResponseDTO<NoContentDTO>.Fail(imageResponse.Message, imageResponse.StatusCode);
                }
                category.ImageUrl = tempImageUrl = imageResponse.Data;
            }
            _mapper.Map(categoryUpdateDTO, category);
            category.UpdatedAt = DateTimeOffset.UtcNow;
            _categoryRepository.Update(category);
            var result = await _unitOfWork.SaveAsync();
            if (result != 1)
            {
                _imageService.DeleteImage(category.ImageUrl!);
                return ResponseDTO<NoContentDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            if (categoryUpdateDTO.Image is not null) _imageService.DeleteImage(oldImageUrl!);
            return ResponseDTO<NoContentDTO>.Success("Kategori başarıyla güncellendi!", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            _imageService.DeleteImage(tempImageUrl);
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}