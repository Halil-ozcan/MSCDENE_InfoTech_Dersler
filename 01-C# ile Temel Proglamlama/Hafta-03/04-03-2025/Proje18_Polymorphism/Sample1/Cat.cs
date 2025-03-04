using System;

namespace Proje18_Polymorphism.Sample1;

public class Cat : Animal
{
    public override void MakeSound(string? name=null)
    {
        Console.WriteLine("Miyavvvvvv");
        base.MakeSound(); // Animal sınıfındaki makeSound'u çalıştır demek.

    }
}
