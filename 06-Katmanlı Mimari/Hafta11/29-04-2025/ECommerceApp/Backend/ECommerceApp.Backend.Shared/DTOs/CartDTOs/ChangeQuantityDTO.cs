using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Backend.Shared.DTOs.CartDTOs;

public class ChangeQuantityDTO
{
    public ChangeQuantityDTO(int cartItemId, int quantity)
    {
        CartItemId = cartItemId;
        Quantity = quantity;
    }

    [Required(ErrorMessage ="CartItem Id bilgisi zorunludur!")]
    public int CartItemId { get; set; }
    [Required(ErrorMessage = "Adet bilgisi zorunludur!")]
    public int Quantity { get; set; }
}
