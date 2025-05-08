using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;

public class CategoryCreateDTO
{
    [Required(ErrorMessage ="Kategori Adı Zorunludur!")]
    public string Name { get; set; }=string.Empty;
    [Required(ErrorMessage ="Kategori Açıklaması Zorunludur!")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage ="Bir Kategori görseli seçmelisiniz!")]
    public IFormFile Image { get; set; }=null!;
}
