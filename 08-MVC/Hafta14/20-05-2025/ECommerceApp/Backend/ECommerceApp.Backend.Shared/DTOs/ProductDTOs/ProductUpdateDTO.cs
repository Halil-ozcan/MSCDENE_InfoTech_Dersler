using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Backend.Shared.DTOs.ProductDTOs;

public class ProductUpdateDTO
{
    [Required(ErrorMessage = "Ürün Id Zorunludur!")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Ürün Adı Zorunludur!")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ürün Özellikleri Zorunludur!")]
    public string Properties { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ürün Fiyatı Zorunludur!")]
    public decimal? Price { get; set; }
    public bool IsHome { get; set; }
    public IFormFile? Image { get; set; } = null!;
    [Required(ErrorMessage = "En az bir kategori seçilmelidir.")]
    public ICollection<int> CategoryIds { get; set; } = [];
}
