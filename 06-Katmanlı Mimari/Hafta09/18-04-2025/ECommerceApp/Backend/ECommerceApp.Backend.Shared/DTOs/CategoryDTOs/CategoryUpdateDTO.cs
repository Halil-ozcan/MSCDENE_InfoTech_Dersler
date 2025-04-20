using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;

public class CategoryUpdateDTO
{
    [Required(ErrorMessage = "Kategori Id bilgisi Zorunludur.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Kategori Adı Zorunludur!")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Kategori Açıklaması Zorunludur!")]
    public string Description { get; set; } = string.Empty;

    // CategoryUpdateDTO da image zorunlu yapmadık çünkü eğer boş gelirse eski resmi kullanmaya devam etmek istediğini düşünecek ve buna göre kodumuzu yapılandıracağız.
    public IFormFile Image { get; set; } = null!;
}
