using System;

public class Triangle : Shape
{
    
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    
    public Triangle(string color, double sideA, double sideB, double sideC) 
        : base(color)  // Calling the base class constructor to set the color
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

   
    public override double GetArea()
    {
        double s = (SideA + SideB + SideC) / 2; 
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC)); 
    }

    
    public override double GetPerimeter()
    {
        return SideA + SideB + SideC; 
    }
}