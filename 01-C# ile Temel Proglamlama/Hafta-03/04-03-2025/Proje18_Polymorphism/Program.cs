using Proje18_Polymorphism.Sample1;

namespace Proje18_Polymorphism;

/*
    Polymorphism(Çok Biçimlilik)
    Bir nesnenin farklı formlarda davranabilmesini ifade eden kavramdır.
*/
class Program
{
    static void Main(string[] args)
    {
        Cat cat1 = new Cat();
        cat1.MakeSound();

        Dog dog1 = new Dog();
        dog1.MakeSound("Karabaş");
    }
}
