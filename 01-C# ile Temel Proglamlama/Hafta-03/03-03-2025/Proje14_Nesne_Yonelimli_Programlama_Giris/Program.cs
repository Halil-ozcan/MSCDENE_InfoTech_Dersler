
namespace Proje14_Nesne_Yonelimli_Programlama_Giris;

/*
    Object Oriented Programming(OOP) 
*/

class Hayvan
{

}


class Program
{
    static void Main(string[] args)
    {


    

        Car car = new Car();
        car.Brand = "Woksvagen";
        car.MaxSpeed = 220;
        car.Model = "Transporter";
        Console.WriteLine(car.Brand);
        Console.WriteLine(car.MaxSpeed);
        Console.WriteLine(car.Model);

        Console.WriteLine();
        Person person = new Person();
        Person person2 = new Person();
        Person person3 = new Person();
        person.FirstName="İrem";
        person.LastName="Sezer";
        person.Age = 22;
        person2.FirstName="Berke";
        person2.LastName="Gönülgül";
        person2.Age = 21;
        person3.FirstName="Ender";
        person3.LastName="Endes";
        person3.Age = 25;

        Person[] persons = [person,person2,person3];
        for (var i = 0; i < persons.Length; i++)
        {
            Console.WriteLine($"Ad: {persons[i].FirstName} Soyad: {persons[i].LastName} Yaş: {persons[i].Age}");
        }
     


        // Car car1 = new Car();
        // car1.SetBrandName("mercedes");
        // Console.WriteLine(car1.GetBrandName());



        // car1.brand = "Opel"; // Bunlara set işlemi yapılıyor.
        // car1.model = "Corsa";
        // car1.maxSpeed = 220;
        // Console.WriteLine($"Marka: {car1.brand}, Model: {car1.model}, Hız: {car1.maxSpeed}"); // burda da get işlemi yapılıyor.




    //     Console.WriteLine("Hello, World!");
    //     Hayvan hayvan = new Hayvan();
    //    Car araba = new Car();
    //    araba.brand = "BMW";
    //    Console.WriteLine(araba.brand);
      
    }

}
