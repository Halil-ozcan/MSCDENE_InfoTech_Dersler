using System;
using ECommerceApp.Backend.Entities.Abstract;

namespace ECommerceApp.Backend.Entities.Concrete;

public class Category:BaseEntity, IEntity
{
    private Category() // EF Core için
    {

    }
    public Category(string name, string imageUrl, string description)
    {
        Name = name;
        ImageUrl = imageUrl;
        Description = description;
    }

    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; } = [];// daha büyük projelerde list kullanılır(Trendyol vb...)
}
