using System;

namespace Proje19_Abstraction.Sample1;

public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public double Height { get; set; }
    public double Width { get; set; }
    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}
