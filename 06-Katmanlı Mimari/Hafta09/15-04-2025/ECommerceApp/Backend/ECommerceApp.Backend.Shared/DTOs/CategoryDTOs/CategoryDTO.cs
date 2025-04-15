using System;

namespace ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; } = [];
}
