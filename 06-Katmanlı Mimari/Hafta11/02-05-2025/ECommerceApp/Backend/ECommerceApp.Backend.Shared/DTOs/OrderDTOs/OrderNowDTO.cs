using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ECommerceApp.Backend.Shared.DTOs.CartDTOs;

namespace ECommerceApp.Backend.Shared.DTOs.OrderDTOs;

public class OrderNowDTO
{
    [JsonIgnore]
    public string? AppUserId { get; set; }

    [Required(ErrorMessage = "Siparişe ait ürün bilgisi zorunludur")]
    public ICollection<OrderItemCreateDTO> OrderItems { get; set; } = [];

    [Required(ErrorMessage = "Adres zorunludur")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Şehir zorunludur")]
    public string? City { get; set; }
}
