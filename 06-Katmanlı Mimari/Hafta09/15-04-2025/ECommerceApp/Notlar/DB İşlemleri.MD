1) Entities katmanında entity'lerimi oluşturuyorum(Veri tabanındaki tablolara karşılık gelecek classlarımız.)
2) Data katmanında DbContext sınıfımız oluşturduk. Bunun içinde de DbSet'lerimizi yazdık ve Configuration'işlemlerini yaptık.(Bu sefer bu işlemleri her entity için ayrı dosyada(Configs klasörü içinde) gerçekleştirdik)
Contstructor metodumuzu yazara DI vasıtasıyla oluşturulan AppDbContext nesnesinin options bilgisini alıp, DbContext base classına ilettik.
3) appsettings.json dosyasına Connection String'imizi yazdık.
4) Program.cs dosyasında AppDbContext nesnemizin kaydını yaptık.(Container'a ekledik) Bunu yaparken, appsettings.json dosyasındaki Connection String'den yararlandık.

5) Şu paketleri yükledik:
Entities: Microsoft.AspNetCore.Identity.EntityFrameworkCore
Data: Microsoft.EntityFrameworkCore.SqlServer
API: Microsoft.EntityFrameworkCore.Design

6) Data Katmanında Migration ve Database Update işlemlerini yaptık.

7) Generic Repository Design Pattern kullanarak Repository'mizi hazırlayıp implemente ettik. UnitOfWork design patternini kullandık.

8) Business