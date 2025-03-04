using System;

namespace Proje17_Inheritance.Sample2;

public class Employee
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal Salary { get; set; }
    public virtual void Work() // virtual kelimesi ile bütün sınıflarda aynı çalışacak sorun olmiyacak ama developer da istersek work metodunu özel olarak değiştirebiliriz demektir. Bu sayede developer sınıfında override yapmış oluyoruz. developer sınıfına baaakkk!!!
    {
        Console.WriteLine($"{FirstName} {LastName} çalışıyor!");
    }
    public void Metot1() // ama burda virtual olmadığı için developer classına bu metotu değiştiremeyiz.
    {
        Console.WriteLine("Herkes için aynı");
    }
}
