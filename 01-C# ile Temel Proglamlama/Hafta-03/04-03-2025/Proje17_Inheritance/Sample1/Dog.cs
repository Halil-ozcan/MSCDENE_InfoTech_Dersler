using System;

namespace Proje17_Inheritance.Sample1;

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine($"{Name} Havladı!");
    }
}
