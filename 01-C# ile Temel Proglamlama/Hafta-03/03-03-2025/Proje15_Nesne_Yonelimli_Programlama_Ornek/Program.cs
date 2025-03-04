namespace Proje15_Nesne_Yonelimli_Programlama_Ornek;
/*
    1-class(Sınıf): Bir nesnenin şablonudur. class'ın içerisinde yer alan yapılara member denir. Özellikler(Properties/Fields) ve Davranışlar(Method) en önemli memberlardır.
    2-Object(nesne): Bir sınıfın somut örneğidir.
    3-Properties/Fields(Özellikler/Alanlar): Bunlar da sınıfın durumlarını tamamlayan değişkenlerdir.
    4-Methods(Davranışlar): Bu sınıftan yaratılan örneğin(nesnenin) yapabilceği işleri tanımlayan fonksiyonlardır.

    OOP Faydaları:
    * Tekrar Kullanabilirlik.
    * Organizasyon
    * Soyutlama
*/
class Program
{
    static void Main(string[] args)
    {
       Person person1 = new Person();
       person1.FirstName ="Alex";
       person1.LastName ="Campbell";
       person1.Age = 45;
       person1.IsActive = true;
       person1.Address = new Address();
       person1.Address.Street = "Alibey Sk.";
       person1.Address.Details = "No:10";
       person1.Address.City = "İstanbul";
       person1.Address.Country = "Türkiye";
       Console.WriteLine(person1.Address.Street);
    }
}
