using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;

public class CategoryCreateDTO
{
    [Required(ErrorMessage = "Kategori Adı Zorunludur!")]
    [DisplayName("Kategori Adı")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Kategori Açıklaması Zorunludur!")]
    [DisplayName("Kategori Açıklaması")]
    public string Description { get; set; } = string.Empty;
    // [Required(ErrorMessage = "Bir Kategori görseli seçmelisiniz!")]
    [DisplayName("Resim Seç")]
    public IFormFile? Image { get; set; } = null!;
}
