using System;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ECommerceApp.Backend.Business.Abstract;

public interface IProductService
{
    Task<ResponseDTO<ProductDTO>> GetAsync(int id, bool includeCategories=false);
    Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isDeleted=false, bool includeCategories=false, int? categoryId=null);
    Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllHomePageAsync();
    Task<ResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO productCreateDTO);
    Task<ResponseDTO<NoContentDTO>> UpdateAsync(ProductUpdateDTO productUpdateDTO);
    Task<ResponseDTO<NoContentDTO>> HardDeleteAsync(int id);//kalıcı silme
    Task<ResponseDTO<NoContentDTO>> SoftDeleteAsync(int id);
    Task<ResponseDTO<int>> CountAsync(bool? isDeleted = false, int? categoryId=null);
    Task<ResponseDTO<NoContentDTO>> UpdateIsHomeAsync(int id);
    Task<ResponseDTO<NoContentDTO>> SoftDeleteByCategoryAsync(int categoryId);


}
