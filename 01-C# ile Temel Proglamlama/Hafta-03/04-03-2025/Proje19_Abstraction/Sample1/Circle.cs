using System;

namespace Proje19_Abstraction.Sample1;

public class Circle : Shape
{
    public Circle(double radius)
    {
        Radius = radius;
    }
    public double Radius { get; set; }
    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius,2);
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
