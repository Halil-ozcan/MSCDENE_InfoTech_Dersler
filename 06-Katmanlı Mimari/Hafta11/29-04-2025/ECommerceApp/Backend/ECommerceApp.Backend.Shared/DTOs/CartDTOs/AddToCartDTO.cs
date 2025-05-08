using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Backend.Shared.DTOs.CartDTOs;

public class AddToCartDTO
{
    [Required(ErrorMessage ="Kullanıcı Id bilgisi zorunludur")]
    public string? AppUserId { get; set; }
    [Required(ErrorMessage ="Ürün Id bilgisi zorunludur!")]
    public int ProductId { get; set; }
    [Required(ErrorMessage ="Adet bilgisi zorunludur!")]
    public int Quantity { get; set; }
}
