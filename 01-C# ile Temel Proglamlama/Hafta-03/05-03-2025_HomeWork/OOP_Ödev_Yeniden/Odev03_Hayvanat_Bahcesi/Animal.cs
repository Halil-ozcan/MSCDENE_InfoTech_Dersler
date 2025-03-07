using System;

namespace Odev03_Hayvanat_Bahcesi;

public abstract class Animal
{
    protected Animal(string tur, string name, string ses)
    {
        Tur = tur;
        Name = name;
        Ses = ses;
    }

    public string Tur { get; set; }
    public string Name { get; set; }
    public string Ses { get; set; }

    public abstract void MakeSound();
}
