using Proje19_Abstraction.Sample1;
using Proje19_Abstraction.Sample2;

namespace Proje19_Abstraction;
/**
    Bir nesnenin karmaşık detaylarını gizleyip, sadece gerekli olan özelliklerin ya da davranışların dışarıya açılmasıdır.


    Abstract
    Interface
*/
class Program
{
    static void Main(string[] args)
    {


        Dog dog1 = new Dog();
        dog1.Eat();
        



    //    Circle circle1 = new Circle(5);
    //    circle1.Display();
    //    Console.WriteLine($"Dairenin Alanı  : {circle1.CalculateArea().ToString("N2")}"); // tostring metotu ile N2 dediğimizde sadece 2 tane basamak değeri olsun diyoruz(78,54)gibi
    //    Console.WriteLine($"Dairenin Çevresi: {circle1.CalculatePerimeter().ToString("N2")}");

    //     Console.WriteLine();

    //    Rectangle rectangle1 = new Rectangle(5,10);
    //    rectangle1.Display();
    //    Console.WriteLine($"Dörgenin Alanı   : {rectangle1.CalculateArea()}");
    //    Console.WriteLine($"Dörgenin çevresi : {rectangle1.CalculatePerimeter()}");

    //    Triangle triangle1 = new Triangle(3,4,5,7);
    //    triangle1.Display();
    //    Console.WriteLine($"Üçgenin Alanı: {triangle1.CalculateArea()}");
    //    Console.WriteLine($"Üçgenin çevresi: {triangle1.CalculatePerimeter()}");

    }
}
