namespace Proje15_Nesne_Yonelimli_Programlama_Ornek;

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
