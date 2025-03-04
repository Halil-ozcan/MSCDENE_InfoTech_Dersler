using System;
using Proje19_Abstraction.Sample1;

namespace Proje19_Abstraction.Sample2;

public class Dog : IAnimal
{
    public void Eat()
    {
       Console.WriteLine("Yemek Yedi");
    }

    public void Fly()
    {
        Console.WriteLine("Köpek Uçamaz");
    }

    public void Jump()
    {
        throw new NotImplementedException();
    }

    public void MakeSound()
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}
