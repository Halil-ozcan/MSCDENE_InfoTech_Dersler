using System;

namespace Proje17_Inheritance.Sample3;

public class Shape
{
    public virtual int CalculateArea()
    {
        return 0;
    }
    public virtual void DrawShape()
    {
        Console.WriteLine("Bir Şekil Çizildi!");
    }
}
