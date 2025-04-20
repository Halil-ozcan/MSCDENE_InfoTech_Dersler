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
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = _unitOfWork.GetRepository<Category>();
        _mapper = mapper;
    }

    public Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<int>> CountAsync(bool? isDeleted = false)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync(bool? isDeleted = false)
    {
        try
        {
            Expression<Func<Category, bool>> myPredicate = x => true;
            if (isDeleted.HasValue)
            {
                myPredicate = x => x.IsDeleted == isDeleted.Value;
            }
            var categories = await _categoryRepository.GetAllAsync(predicate: myPredicate, includeDeleted: isDeleted ?? false);
            if (!categories.Any())
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Hiç kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            // Resim kontrolü yapılacak
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
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);//aşağıdaki işlemin aynısını yapıyor.
            // Resim Kontrolü yapcaz.
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, "Kategori başarıyla gönderildi", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<CategoryDTO>.Fail($"Beklenmedik Hata:{ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public Task<ResponseDTO<NoContentDTO>> HardDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> SoftDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
    {
        throw new NotImplementedException();
    }
}


// CategoryDTO categoryDTO = new()
// {
//     Id=category.Id,
//     Name=category.Name,
//     Description = category.Description,
//     ImageUrl = category.ImageUrl,
//     IsDeleted = category.IsDeleted,
//     CreatedAt = category.CreatedAt,
//     DeletedAt = category.DeletedAt,
//     UpdatedAt = category.UpdatedAt
// };