using System;

namespace Odev3_Zoo_Managment;

public class Monkey : Animal
{
    public Monkey(string species, string name) : base(species, name)
    {

    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} ({Species}) ses çıkarıyor: oo-oo-aa-aa");
    }
}
