# EF Core ile Çalışmak

1. Microsoft.EntityFrameworkCore.SqlServer paketini yüklüyoruz. Paketi yüklerken versiyonuna dikkat etmeliyiz. Biz .Net 8 ile çalıştığımız için bu .Net sürümüne uygun bir paket versiyonu seçmeliyiz.(8.0.11, 8.0.12 vb) 
    - dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.14

2. EF Core ile çalışırken terminal üzerinden dotnet cli'inı kullanırken gerekli olan dotnet-ef tool'unu yüklüyoruz.
    - dotnet tools install --global dotnet-ef --version 8.0.14
    * not: Bu paketi bilgisayarınıza bir kez kurduğunuzda bir daha kurmanıza gerek kalmayacaktır. Ancak bir versiyon güncellemesi gerekirse update işlemi yapılabilir.

3. EF Core ile yaptıklarımızı veritabanı sunucusuna/veri tabanına yansıtmabilmek için yapacağımız migration/database update gibi işlemlerin çalışması için bir pakete daha ihtiyacımız var. Bunun için Microsoft.EntityFrameworkCore.Design paketinin 8.0.14 versiyonunu yüklüyoruz.
    - dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.14

4. Modellerimizi hazırlıyoruz. Ki artık EF Core ile çalışırken bunlara yani veri tabanındaki tablolarımızdaki her bir kaydı temsil eden uygulamamızdaki sınıflara "Entity"(varlık) diyoruz. (Product, Catgorory, Customer vb.)

5. DbContext sınıfımızı yaratıyoruz. Bu sınıf genellikle AppDbContext, ApplicationDbContext, BookAppDbContext, TicketSystemDbContext gibi isimlendirilir. Ve EF Core'dan gelen DbContext sınıfından miras alınır.
Bu sınıfın içerisinde her bir entity(yani tablolarımıza karşılık gelen sınıf) için bir DbSet tanımlaması yapılarak, hangi tabloyla eşleştirildikleri belirtilir.

6. appsettings.json dosyasındaki ConnectionString bilgisini kullanarak, Program.cs dosyasında DbContext sınıfımız için servis kaydını yapıyoruz.
    - builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

7. C# tarafında yptığımız bu çalışmaları artık veri tabanına aktarmaya başlayabiliriz. Bu işlemi iki aşamada gerçekleştiriyoruz:
    1. Migration: Yaptıklarımızın veri tabanına yansımasını sağlayacak c# kodlarını içeren bir takım dosyalar yaratmak.
    2. Database Update: Bir önceki adımda oluşturulan migrationları veri tabanına yansıtmak üzere çalıştırır. Yani veri tabanına güncelleme yapar.(eğer ilk kez çalıştırılıyor ve veri tabanı yok ise; oluşturur)
