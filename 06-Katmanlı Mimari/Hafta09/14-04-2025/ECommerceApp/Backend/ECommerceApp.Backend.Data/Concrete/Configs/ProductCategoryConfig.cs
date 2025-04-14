using System;
using ECommerceApp.Backend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Backend.Data.Concrete.Configs;

public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(x => new { x.ProductId, x.CategoryId });
        builder.HasData(
            // Ürün 1–5: 4 kategori
            new ProductCategory(1, 1),
            new ProductCategory(1, 2),
            new ProductCategory(1, 3),
            new ProductCategory(1, 4),
            new ProductCategory(2, 2),
            new ProductCategory(2, 3),
            new ProductCategory(2, 5),
            new ProductCategory(2, 6),
            new ProductCategory(3, 1),
            new ProductCategory(3, 4),
            new ProductCategory(3, 7),
            new ProductCategory(3, 8),
            new ProductCategory(4, 2),
            new ProductCategory(4, 5),
            new ProductCategory(4, 9),
            new ProductCategory(4, 10),
            new ProductCategory(5, 1),
            new ProductCategory(5, 3),
            new ProductCategory(5, 6),
            new ProductCategory(5, 7),

            // Ürün 6–10: 3 kategori
            new ProductCategory(6, 2),
            new ProductCategory(6, 4),
            new ProductCategory(6, 5),
            new ProductCategory(7, 1),
            new ProductCategory(7, 3),
            new ProductCategory(7, 8),
            new ProductCategory(8, 6),
            new ProductCategory(8, 7),
            new ProductCategory(8, 10),
            new ProductCategory(9, 2),
            new ProductCategory(9, 5),
            new ProductCategory(9, 9),
            new ProductCategory(10, 1),
            new ProductCategory(10, 4),
            new ProductCategory(10, 8),

            // Ürün 11–20: 2 kategori
            new ProductCategory(11, 3),
            new ProductCategory(11, 5),
            new ProductCategory(12, 6),
            new ProductCategory(12, 7),
            new ProductCategory(13, 1),
            new ProductCategory(13, 9),
            new ProductCategory(14, 2),
            new ProductCategory(14, 4),
            new ProductCategory(15, 3),
            new ProductCategory(15, 8),
            new ProductCategory(16, 4),
            new ProductCategory(16, 6),
            new ProductCategory(17, 5),
            new ProductCategory(17, 7),
            new ProductCategory(18, 1),
            new ProductCategory(18, 10),
            new ProductCategory(19, 2),
            new ProductCategory(19, 3),
            new ProductCategory(20, 8),
            new ProductCategory(20, 9),

            // Ürün 21–30: 1 kategori
            new ProductCategory(21, 1),
            new ProductCategory(22, 2),
            new ProductCategory(23, 3),
            new ProductCategory(24, 4),
            new ProductCategory(25, 5),
            new ProductCategory(26, 6),
            new ProductCategory(27, 7),
            new ProductCategory(28, 8),
            new ProductCategory(29, 9),
            new ProductCategory(30, 10)
        );
    }
}
