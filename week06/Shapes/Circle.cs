using System;

public class Circle : Shape
{
    
    private double _radius;
   
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    
    public override double GetPerimeter()
    {
        return 2 * Math.PI * _radius;
    }
}