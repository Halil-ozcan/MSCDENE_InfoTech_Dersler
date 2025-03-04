using System;

namespace Proje18_Polymorphism.Sample1;

public class Dog : Animal
{
    public string? Name { get; set; }
    public override void MakeSound(string? name)
    {
        Name = name;
        Console.WriteLine($"{Name}: Hav Hav!");
        base.MakeSound();
    }
}
