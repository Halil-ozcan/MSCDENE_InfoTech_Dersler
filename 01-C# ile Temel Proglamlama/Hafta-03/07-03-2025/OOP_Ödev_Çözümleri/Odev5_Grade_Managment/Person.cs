using System;

namespace Odev5_Grade_Managment;

public abstract class Person
{
    protected Person(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public abstract void DisplayInfo();
    
}
