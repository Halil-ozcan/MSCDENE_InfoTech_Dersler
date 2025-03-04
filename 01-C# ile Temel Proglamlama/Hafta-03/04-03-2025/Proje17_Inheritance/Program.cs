using System.Security.Cryptography;
using Proje17_Inheritance.Sample1;
using Proje17_Inheritance.Sample2;
using Proje17_Inheritance.Sample3;

namespace Proje17_Inheritance;
/*
    Inheritance(Kalıtım/Miras)
    Bir Sınfıın sahip olduğu property yada metotları başka sınıflara devretmesine Inheritance(kalıtım/miras) diyoruz.

*/
class Program
{
    static void Main(string[] args)
    {


        Circle circle1 = new Circle();
        circle1.DrawShape();
       Console.WriteLine( circle1.CalculateArea());
        Rectangle rectangle1 = new Rectangle();
        rectangle1.DrawShape();
       Console.WriteLine( rectangle1.CalculateArea());





        // Manager manager1 = new Manager();
        // manager1.FirstName = "Ali";
        // manager1.LastName = "Cabbar";
        // manager1.Bonus = 55000;
        // manager1.Salary = 125000;
        // manager1.Work();
        // manager1.ConductMeet();

        // Console.WriteLine();

        // Developer developer1 = new Developer();
        // developer1.FirstName = "Halil";
        // developer1.LastName = "Özcan";
        // developer1.Salary = 60000;
        // developer1.ProgrammingLanguage="C#";
        // developer1.Work();
        






    //    Cat cat = new Cat();
    //    cat.Name = "Heda";
    //    cat.Eat();
    //    cat.Meaw();

    //    Console.WriteLine();

    //    Dog dog = new Dog();
    //    dog.Name = "Karabaş";
    //    dog.Eat();
    //    dog.Bark();
    }
}
