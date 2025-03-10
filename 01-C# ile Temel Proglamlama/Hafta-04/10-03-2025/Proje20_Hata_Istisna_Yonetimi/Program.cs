namespace Proje20_Hata_Istisna_Yonetimi;

class Program
{
    static void Main(string[] args)
    {
       #region Intro
        
       #endregion

       #region Temel Kullanım
        // Console.Clear();
        // Console.WriteLine();
        // try
        // {
        //     Console.Write("Yaşınızı Giriniz: ");
        //     int age = int.Parse(Console.ReadLine()!);
        //     Console.Write("Vitamin değerini giriniz: ");
        //     int value = int.Parse(Console.ReadLine()!);
        //     Console.Write("Adınızı Girin: ");
        //     string name = Console.ReadLine()!;

        //     Console.WriteLine($"Sayın{name},{age} yaşındasınız. Adınız {name.Length} karaketer uzunluğunda.({name.ToUpper()})");
        //     Console.WriteLine($"Gelişme Katsayınız: {age/value}");
        // }
        // catch(FormatException ex)
        // {
        //     Console.WriteLine("Lütfen bir sayı giriniz!");
        // }
        // catch(DivideByZeroException ex)
        // {
        //     Console.WriteLine("Lütfen 0 dışında bir sayı giriniz!");
        // }
        // catch (Exception exception)
        // {
        //    Console.WriteLine($"Bir hata oluştu: {exception.Message}");
        // }
       #endregion

       #region Bazı Hata(Exception) Türleri
            /*
                FormatException: Veri türü uyumsuzluğu
                DivedByZeroException: 0'a bölünme
                NullReferenceException: null olan bir nesnenin kullanılması
                ArgumentNullException: metota'a null bir argüman göderilmesi
                IndexOutOFRangeException: Bir dizinin geçersiz indeksine erişilmesi.
                Excepiton: Genel hata türü, diğer tüm türlerin base class'ı.
            */        
       #endregion

       #region NullReferenceException
        // try
        // {
        //     Category category1 = new Category();
        //     Console.Write("Category Id: ");
        //     category1.Id = int.Parse(Console.ReadLine()!);
        //     Console.WriteLine(100 / category1.Id);
        //     Console.WriteLine(category1.IsActive ? "Aktif" : "Pasif");
        //     Console.WriteLine(category1.Name.Length);
        // }
        // catch (NullReferenceException ex)
        // {
        //      Console.WriteLine("Null Referans hatası!");
        // }
        // catch(DivideByZeroException ex)
        // {
        //     Console.WriteLine("sıfıra bölünme hatası!");
        // }
        // catch(Exception ex)
        // {
        //     Console.WriteLine($"Bir sorun oluştu: {ex.Message}");
        // }
       #endregion

       #region NullReferenceException2
        // Category category1 = new Category();
        // category1.Id = 1;
        // category1.Name = "Telefon";
        // category1.Description = "Telefonlar Burada";
        // category1.IsActive = true;

        // Category category2 = new Category();
        // category2.Id = 2;
        // category2.Name = "Bilgisayar";
        // category2.Description = "Bilgisayar Burada";
        // category2.IsActive = true;

        // Product product1 = new Product();
        // product1.Id = 1;
        // product1.Name = "Iphone 14";
        // product1.Description = "Güzel bir telefon";
        // product1.Price = 50000;

        // Console.WriteLine(product1.Name);
        // Console.WriteLine(product1.Category.Name);// NullReferenceException Hatası verir.

       #endregion

       #region Sample01

    //    try
    //    {
    //         Console.Clear();
    //         Console.Write("ÜRÜN ADEDİ: ");
    //         int count = int.Parse(Console.ReadLine()!);

    //         Product[] products = new Product[count];
    //         Product product;
    //         Category category;
    //         for (int i = 0; i < products.Length; i++)
    //         {
    //             Console.WriteLine($"{i + 1}. ÜRÜN BİLGİLERİ");
    //             Console.WriteLine("------------------------");

    //             Console.Write("Id: ");
    //             int id = int.Parse(Console.ReadLine()!);

    //             Console.Write("Ad: ");
    //             string name = Console.ReadLine()!;

    //             Console.Write("Açıklama: ");
    //             string description = Console.ReadLine()!;

    //             Console.Write("Fiyat: ");
    //             decimal price = decimal.Parse(Console.ReadLine()!);

    //             Console.Write("\tÜRÜNÜN KATEGORİSİNE AİT BİLGİLER");

    //             Console.Write("\tKategori Id: ");
    //             int categoryId = int.Parse(Console.ReadLine()!);

    //             Console.Write("\tCategory Ad: ");
    //             string categoryName = Console.ReadLine()!;

    //             Console.Write("\tCategory Açıklama: ");
    //             string categoryDescription = Console.ReadLine()!;

    //             category = new Category(categoryName, categoryDescription);
    //             category.Id = categoryId;

    //             product = new Product(name,description,category);
    //             product.Id = id;
    //             product.Price = price;

    //             products[i] = product;

    //         }
    //         Console.WriteLine();
    //         Console.WriteLine("---------------------------------");
    //         Console.WriteLine();
    //         Console.WriteLine("ÜRÜN LİSTESİ");
    //         Console.WriteLine("----------------------------------");
    //         foreach (Product nextProduct in products)
    //         {
    //             Console.WriteLine($"Ürün: {nextProduct.Name} - Kategori: {nextProduct.Category.Name} - Fiyat: {nextProduct.Price:C2} - KDV Dahil Fiyat: {nextProduct.Price * 1.25m:C2}");
    //         }
    //    }
    //    catch (FormatException)
    //    {
    //     Console.WriteLine("Geçersiz formatta değer girdiğiniz için program durduruldu.");
    //    }
    //    catch(IndexOutOfRangeException)
    //    {
    //     Console.WriteLine("Geçerli aralık dışında bir indise erişilmeye çalışıldığından dolayı program durduruldu.");
    //    }
    //    catch(NullReferenceException)
    //    {
    //     Console.WriteLine("Kullanmaya çalıştığınız objenin değeri olmadığından dolayı program durduruldu");
    //    }
    //    catch(Exception ex)
    //    {
    //     Console.WriteLine($"Beklenmedik bir sorun oluştuğundan dolayı program durduruldu. Sistemin mesajı: {ex.Message}");
    //    }
       #endregion

       #region Sample02
        try
        {
            Console.Clear();
            Console.Write("Okumak istediğiniz dosyanın adını yazınız: ");
            string fileName = Console.ReadLine()!;
            string fileContent = File.ReadAllText(fileName);
            Console.WriteLine($"{fileName} adlı dosyanın içeriği aşağıdaır.");
            Console.WriteLine(fileContent);
        }
        catch (FileNotFoundException)
        {
             Console.WriteLine("Dosya bulunamadığı için okunamadı!");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
        }

       #endregion
    }


}
