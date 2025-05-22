using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;

namespace ECommerceApp.Backend.Shared.DTOs.OrderDTOs;

public class OrderItemCreateDTO
{
    [Required(ErrorMessage = "Ürün id bilgisi zorunludur")]
    public int ProductId { get; set; }
    [JsonIgnore]
    public ProductDTO? Product { get; set; }

    [Required(ErrorMessage = "Ürün fiyatı zorunludur")]
    [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır!")]
    public decimal UnitPrice { get; set; }

    [Required(ErrorMessage = "Adet bilgisi zorunludur")]
    [Range(1, 100, ErrorMessage = "En fazla 100 adet ürün sipariş edebilirsiniz!")]
    public int Quantity { get; set; }
    [JsonIgnore]
    public decimal TotalItem => UnitPrice * Quantity;
}
