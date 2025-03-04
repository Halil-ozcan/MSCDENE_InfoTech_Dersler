using System;

namespace Proje19_Abstraction.Sample1;

public class Triangle : Shape
{
    public Triangle(double baseSide, double sideA, double sideB, double height)
    {
        BaseSide = baseSide;
        SideA = sideA;
        SideB = sideB;
        Height = height;
    }

    public double BaseSide { get; set; }
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double Height { get; set; }
    public override double CalculateArea()
    {
        return BaseSide * (Height / 2);
    }

    public override double CalculatePerimeter()
    {
       return BaseSide + SideA + SideB;
    }
}
