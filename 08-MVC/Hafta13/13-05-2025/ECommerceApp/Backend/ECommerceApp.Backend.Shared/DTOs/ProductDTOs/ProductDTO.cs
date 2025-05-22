using System;
using ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;

namespace ECommerceApp.Backend.Shared.DTOs.ProductDTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Properties { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsHome { get; set; }
    public ICollection<CategoryDTO> Categories { get; set; }=[];
}
