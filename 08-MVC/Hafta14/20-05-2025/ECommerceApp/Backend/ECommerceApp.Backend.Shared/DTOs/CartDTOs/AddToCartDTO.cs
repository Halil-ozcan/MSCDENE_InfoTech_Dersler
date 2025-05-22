using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerceApp.Backend.Shared.DTOs.CartDTOs;

public class AddToCartDTO
{
    [JsonIgnore]
    public string? AppUserId { get; set; }
    [Required(ErrorMessage ="Ürün Id bilgisi zorunludur!")]
    public int ProductId { get; set; }
    [Required(ErrorMessage ="Adet bilgisi zorunludur!")]
    public int Quantity { get; set; }
}
