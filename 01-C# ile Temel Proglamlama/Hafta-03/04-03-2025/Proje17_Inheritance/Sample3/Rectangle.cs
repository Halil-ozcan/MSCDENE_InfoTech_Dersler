using System;

namespace Proje17_Inheritance.Sample3;

public class Rectangle : Shape
{
    public override void DrawShape()
    {
        base.DrawShape();
        Console.WriteLine("Bir Dörtgen Çizildi");
        
    }
    public override int CalculateArea()
    {
        return 46;
    }
}
