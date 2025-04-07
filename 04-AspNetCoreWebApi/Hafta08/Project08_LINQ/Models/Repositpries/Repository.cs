using System;

namespace Project08_LINQ.Models.Repositpries;

public class Repository
{
 public static List<Category> Categories=[
        new Category{Id=1,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Telefon",Description="Telefon Ürünleri Burada"},
        new Category{Id=2,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Bilgisayar",Description="Bilgisayar Ürünleri Burada"},
        new Category{Id=3,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Mutfak",Description="Mutfak Ürünleri Burada"},
        new Category{Id=4,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Mobilya",Description="Mobilya Ürünleri Burada"}
    ];
    public static List<Supplier> Suppliers=[
        new Supplier{Id=1,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,CompanyName="ABC Toptancılık",Address="Kadıköy",city="İstanbul"},
        new Supplier{Id=2,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,CompanyName="Halil Bey Toptancılık",Address="Çeşme",city="İzmir"},
        new Supplier{Id=3,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,CompanyName="ŞakirPaşa Toptancılık",Address="Yenimahalle",city="Ankara"}
    ];
    public static List<Product> Products=[
        // Telefon
        new Product{Id=1,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Iphone 16 Pro", Properties="Güzel Telefon",Price=78000,Stock=16,CategoryId=1,SupplierId=1},
        new Product{Id=2,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=true,Name="Iphone 17 Pro", Properties="Güzel Telefon",Price=88000,Stock=116,CategoryId=1,SupplierId=1},
        new Product{Id=3,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Iphone 18 Pro", Properties="Güzel Telefon",Price=98000,Stock=166,CategoryId=1,SupplierId=2},

        //Bilgisayar
        new Product{Id=4,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Mackbook Pro M4", Properties="24 GB Ram",Price=48000,Stock=116,CategoryId=2,SupplierId=2},
        new Product{Id=5,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Mackbook Pro M5", Properties="Güzel Bilgisayar",Price=58000,Stock=126,CategoryId=2,SupplierId=2},
        new Product{Id=6,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=true,Name="Mackbook Pro M6", Properties="Güzel Bilgisayar",Price=68000,Stock=136,CategoryId=2,SupplierId=2},
        new Product{Id=7,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Mackbook Pro M7", Properties="Güzel Bilgisayar",Price=88000,Stock=146,CategoryId=2,SupplierId=1},

        // Mutfak
        new Product{Id=8,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Düdüklü Tencere", Properties="Güzel Tencere",Price=7000,Stock=160,CategoryId=3,SupplierId=3},
        new Product{Id=9,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="Setüstü Ocak", Properties="Güzel Ocak",Price=8000,Stock=120,CategoryId=3,SupplierId=3},

        //Mobilya
        new Product{Id=10,CreatedAt=DateTime.UtcNow,UpdatedAt=DateTime.UtcNow,IsDeleted=false,Name="L Koltuk Takımı", Properties="Güzel Koltuk",Price=38000,Stock=20,CategoryId=4,SupplierId=3},

    ];
}
