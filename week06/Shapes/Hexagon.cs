using System;

public class Hexagon : Shape
{
    
    private double _side;

    
    public Hexagon(string color, double side) : base(color)
    {
        _side = side;
    }

    
    public override double GetArea()
    {
        return (3 * Math.Sqrt(3) / 2) * _side * _side;
    }

    
    public override double GetPerimeter()
    {
        return 6 * _side;
    }
}