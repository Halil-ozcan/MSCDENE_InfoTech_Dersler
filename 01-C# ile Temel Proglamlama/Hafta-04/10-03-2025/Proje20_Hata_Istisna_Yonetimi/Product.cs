using System;

namespace Proje20_Hata_Istisna_Yonetimi;

public class Product
{
    public Product(string name, string description, Category category)
    {
        Name = name;
        Description = description;
        Category = category;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }

}
