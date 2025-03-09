using System;

namespace Odev05_Not_Hesaplama;

public abstract class Person
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public abstract void DisplayInfo();

}
