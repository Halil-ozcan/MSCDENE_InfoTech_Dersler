using System;

namespace Proje19_Abstraction.Sample1;

public abstract class Shape
{
    // bir sinifin içeriisnde abstarct metot kullanmak için abstarct sınıf olması gerekir.
    public abstract double CalculateArea(); // alan hesabı
    public abstract double CalculatePerimeter(); // Çevre Hesabı
    public virtual void Display()
    {
        Console.WriteLine("Bu bir şekil nesnesidir.");
    }
}
