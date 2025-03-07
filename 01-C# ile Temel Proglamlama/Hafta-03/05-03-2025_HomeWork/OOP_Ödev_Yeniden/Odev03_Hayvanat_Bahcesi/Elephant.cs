using System;

namespace Odev03_Hayvanat_Bahcesi;

public class Elephant : Animal
{
    public Elephant(string tur, string name, string ses) : base(tur, name, ses)
    {

    }

    public override void MakeSound()
    {
       Console.WriteLine($"{Name} ({Tur}) Ses Çıkarıyor {Ses}");
    }
}
