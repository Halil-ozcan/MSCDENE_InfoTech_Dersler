using System;
using ECommerceApp.Backend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Backend.Data.Concrete.Configs;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x=>x.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.ImageUrl)
            .IsRequired();
        builder.Property(x => x.Properties)
            .IsRequired();
        builder.Property(x=>x.Price).HasColumnType("decimal(10,2)");

        builder.HasData(
            new Product("iPhone 13", "128GB, Siyah", 32999.99m, "product1.png", true) { Id = 1 },
            new Product("Samsung Galaxy S22", "256GB, Beyaz", 28999.50m, "product2.png", true) { Id = 2 },
            new Product("Dell XPS 13", "Intel i7, 16GB RAM", 44999.00m, "product3.png", false) { Id = 3 },
            new Product("MacBook Air M2", "512GB SSD", 51999.99m, "product4.png", true) { Id = 4 },
            new Product("Sony Bravia 55\"", "4K UHD Smart TV", 23999.99m, "product5.png", false) { Id = 5 },
            new Product("Nike Air Max", "Erkek Spor Ayakkabı", 2499.99m, "product6.png", true) { Id = 6 },
            new Product("Adidas Sweatshirt", "Oversize, Siyah", 899.99m, "product7.png", false) { Id = 7 },
            new Product("Koltuk Takımı", "3+2+1, Gri", 18999.00m, "product8.png", false) { Id = 8 },
            new Product("Ahşap Masa", "150x90 cm, Ceviz", 4999.50m, "product9.png", true) { Id = 9 },
            new Product("Zigon Sehpa", "3'lü, Beyaz", 999.99m, "product10.png", false) { Id = 10 },
            new Product("Harry Potter Seti", "7 Kitap, Türkçe", 1499.00m, "product11.png", true) { Id = 11 },
            new Product("Yüzüklerin Efendisi", "3'lü Kitap Seti", 899.99m, "product12.png", true) { Id = 12 },
            new Product("Puzzle 1000 Parça", "Manzara Temalı", 299.99m, "product13.png", false) { Id = 13 },
            new Product("Oyuncak Araba", "Uzaktan Kumandalı", 599.99m, "product14.png", false) { Id = 14 },
            new Product("Diş Fırçası", "Elektrikli, Şarjlı", 799.00m, "product15.png", true) { Id = 15 },
            new Product("Yüz Temizleme Jeli", "200ml", 149.99m, "product16.png", false) { Id = 16 },
            new Product("Bebek Bezi", "5 Numara, 40'lı", 349.99m, "product17.png", false) { Id = 17 },
            new Product("Bebek Maması", "800g", 289.99m, "product18.png", false) { Id = 18 },
            new Product("Kedi Maması", "2 Kg", 249.00m, "product19.png", false) { Id = 19 },
            new Product("Köpek Oyuncağı", "Dayanıklı Kauçuk", 129.99m, "product20.png", false) { Id = 20 },
            new Product("Tenis Raketi", "Profesyonel", 1999.99m, "product21.png", true) { Id = 21 },
            new Product("Koşu Bandı", "Katlanabilir", 8999.00m, "product22.png", false) { Id = 22 },
            new Product("Makyaj Seti", "5'li Allık & Far", 799.99m, "product23.png", true) { Id = 23 },
            new Product("Parfüm", "Kadın, 50ml", 599.00m, "product24.png", false) { Id = 24 },
            new Product("Organik Elma", "1 Kg", 39.99m, "product25.png", false) { Id = 25 },
            new Product("Zeytinyağı", "1 Litre, Soğuk Sıkım", 129.99m, "product26.png", false) { Id = 26 },
            new Product("Çamaşır Deterjanı", "4 Kg", 189.99m, "product27.png", false) { Id = 27 },
            new Product("Kamp Çadırı", "2 Kişilik", 999.00m, "product28.png", true) { Id = 28 },
            new Product("Powerbank", "20.000 mAh", 499.00m, "product29.png", true) { Id = 29 },
            new Product("Bluetooth Kulaklık", "Gürültü Engelleyici", 1299.99m, "product30.png", false) { Id = 30 }
        );
    }
}
