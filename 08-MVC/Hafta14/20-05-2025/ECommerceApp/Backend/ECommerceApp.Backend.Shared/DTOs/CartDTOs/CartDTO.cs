using System;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;

namespace ECommerceApp.Backend.Shared.DTOs.CartDTOs;

public class CartDTO
{
    public int Id { get; set; }
    public string? AppUserId { get; set; }
    public AppUserDTO? AppUser { get; set; }
    public ICollection<CartItemDTO> CartItems { get; set; } = [];
    public decimal CartTotalAmount => CartItems.Sum(x=>x.TotalAmount);
    public int CartItemsCount => CartItems.Count;
}
