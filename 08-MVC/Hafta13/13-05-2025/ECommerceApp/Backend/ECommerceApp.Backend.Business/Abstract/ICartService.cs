using System;
using ECommerceApp.Backend.Shared.DTOs.CartDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ECommerceApp.Backend.Business.Abstract;

public interface ICartService
{
    Task<ResponseDTO<CartDTO>> CreateCartAsync(CartCreateDTO cartCreateDTO);
    Task<ResponseDTO<CartDTO>> GetCartAsync(string appUserId);
    Task<ResponseDTO<CartItemDTO>> AddToCartAsync(AddToCartDTO addToCartDTO);
    Task<ResponseDTO<NoContentDTO>> RemoveFromCartAsync(int cartItemId);
    Task<ResponseDTO<NoContentDTO>> ClearCartAsync(string appUserId);
    Task<ResponseDTO<NoContentDTO>> ChangeQuantityAsync(ChangeQuantityDTO changeQuantityDTO); 
}
