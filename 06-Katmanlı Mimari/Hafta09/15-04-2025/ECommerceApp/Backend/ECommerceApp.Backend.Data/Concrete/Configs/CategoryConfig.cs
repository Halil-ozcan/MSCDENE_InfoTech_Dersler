using System;
using ECommerceApp.Backend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Backend.Data.Concrete.Configs;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x=>x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x=>x.ImageUrl)
            .IsRequired();
        builder.Property(x=>x.Description)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.HasData(
            new Category("Telefon","categori1.png","Telefon Kategorisi"){Id=1}, 
            new Category("Bilgisayar","categori2.png","Bilgisayar Kategorisi") { Id = 2 }, 
            new Category("Televizyon","categori3.png","Televizyon Kategorisi") { Id = 3 }, 
            new Category("Ayakkabı","categori4.png","Ayakkabı Kategorisi") { Id = 4 }, 
            new Category("Giyim","categori5.png","Giyim Kategorisi") { Id = 5 }, 
            new Category("Mobilya","categori6.png","Mobilya Kategorisi") { Id = 6 }, 
            new Category("Kitap","categori7.png","Kitap Kategorisi") { Id = 7 }, 
            new Category("Oyuncak","categori8.png","Oyuncak Kategorisi") { Id = 8 }, 
            new Category("Kozmetik","categori9.png","Kozmetik Kategorisi") { Id = 9 }, 
            new Category("SporMalzemeleri","categori10.png","Spor Malzemeleri Kategorisi") { Id = 10 }
        );
        builder.HasQueryFilter(x=>!x.IsDeleted);//Her zaman IsDeleted'ı false olanlarla çalış.
        

    }
}
