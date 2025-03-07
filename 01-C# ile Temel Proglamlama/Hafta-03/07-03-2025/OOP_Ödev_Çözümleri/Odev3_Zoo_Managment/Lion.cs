using System;

namespace Odev3_Zoo_Managment;

public class Lion : Animal
{
    public Lion(string species, string name) : base(species, name)
    {

    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} ({Species}) ses çıkarıyor: ROOAAAARRRRR!");
    }
}
