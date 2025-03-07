using System;

namespace Odev3_Zoo_Managment;

public abstract class Animal
{
    public Animal(string species, string name)
    {
        Species = species;
        Name = name;
    }

    public string Species { get;  set; } 
    public string Name { get; } // set işlemi kaldırıldığında readonly(saltokunur) olur. private set yaptığımızda ise sadece bu sınıftan erişim olur.

    public abstract void MakeSound();

}
