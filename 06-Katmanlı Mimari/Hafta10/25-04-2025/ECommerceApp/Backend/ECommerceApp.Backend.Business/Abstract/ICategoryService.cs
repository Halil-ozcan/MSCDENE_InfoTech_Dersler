using System;
using ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ECommerceApp.Backend.Business.Abstract;

public interface ICategoryService
{
    Task<ResponseDTO<CategoryDTO>> GetAsync(int id);
    Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync(bool? isDeleted = false);
    Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO);
    Task<ResponseDTO<NoContentDTO>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO);
    Task<ResponseDTO<NoContentDTO>> HardDeleteAsync(int id);//kalıcı silme
    Task<ResponseDTO<NoContentDTO>> SoftDeleteAsync(int id);
    Task<ResponseDTO<int>> CountAsync(bool? isDeleted = false);


}
