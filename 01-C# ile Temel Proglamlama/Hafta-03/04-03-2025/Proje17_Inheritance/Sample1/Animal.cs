using System;

namespace Proje17_Inheritance.Sample1;

public class Animal
{
    public string?  Name { get; set; }
    public void Eat()
    {
        Console.WriteLine($"{Name} Yemek Ye!");
    }
}
