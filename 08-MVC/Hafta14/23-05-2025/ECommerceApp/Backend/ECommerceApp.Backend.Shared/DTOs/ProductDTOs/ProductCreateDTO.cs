using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Backend.Shared.DTOs.ProductDTOs;

public class ProductCreateDTO
{
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

/*
Kullanıcı yeni ürün oluşturma ekranında ona listelediğimiz tüm kategoriler arasından, ürünün kategorilerini işaretlemiş olacak. Örneğin 3 tane kategoriyi seçmiş olsun.
Kaydet dediğinde, bu seçili olan kategorilerin Id değerlerini alman gerekiyor. Birden fazla olma ihtimali olduğu için bir collection ile (CategoryIds) bu bilgileri arıyorum.
İlerleyen aşamada, kayıt işlemi yapılırken önce Product bilgisini Products tablosuna kaydedeceğim. Hemen ardından artık bu Product'ın bir Id değeri olduğu için ProductCategories tablosuna ProductId-CategoryId ikililerini kaydedebilirim. 

Yeni oluşturulan ürünün Id değeri, ProductId=93
Bu ürün oluşturulurken kullanıcının seçtiği kategorilerin id'leri, CategoryIds=[5,9,3]

ProductCategories
93-5
93-9
93-3
*/
