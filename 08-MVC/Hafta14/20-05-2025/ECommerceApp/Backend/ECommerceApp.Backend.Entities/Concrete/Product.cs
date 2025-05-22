using System;
using ECommerceApp.Backend.Entities.Abstract;

namespace ECommerceApp.Backend.Entities.Concrete;

public class Product:BaseEntity,IEntity
{
    private Product() // EF Core için
    {

    }
    public Product(string? name, string? properties, decimal price, string? imageUrl, bool isHome)
    {
        Name = name;
        Properties = properties;
        Price = price;
        ImageUrl = imageUrl;
        IsHome = isHome;
    }
    
    public string? Name { get; set; }
    public string? Properties { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsHome { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }=[];// daha büyük projelerde list kullanılır(Trendyol vb...)
}
