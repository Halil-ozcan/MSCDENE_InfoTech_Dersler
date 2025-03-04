using System;

namespace Proje17_Inheritance.Sample3;

public class Circle : Shape
{
    public override void DrawShape()
    {
        
        Console.WriteLine("Bir daire Çizildi!");
    }
    public override int CalculateArea()
    {
        return 40;
    }
}
