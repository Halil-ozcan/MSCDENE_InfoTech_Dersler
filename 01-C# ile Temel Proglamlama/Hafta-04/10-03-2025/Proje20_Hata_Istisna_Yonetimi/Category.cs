using System;

namespace Proje20_Hata_Istisna_Yonetimi;

public class Category
{
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
