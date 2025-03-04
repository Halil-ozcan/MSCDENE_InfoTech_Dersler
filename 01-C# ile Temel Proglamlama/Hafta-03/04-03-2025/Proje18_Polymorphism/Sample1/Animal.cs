using System;

namespace Proje18_Polymorphism.Sample1;

public class Animal
{
    public virtual void MakeSound(string? name=null)
    {
        Console.WriteLine($"{name??"Hayvan"} ses çıkarıyor...");// 
    }

    public void Eat()
    {
        Console.WriteLine("Yemek Yedi");
    }
    public void Jump()
    {
        Console.WriteLine("Hayvan Zıpladı");
    }
}
