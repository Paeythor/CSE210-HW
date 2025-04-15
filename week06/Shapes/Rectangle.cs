using System;

public class Rectangle : Shape
{
    
    private double _length;
    private double _width;

    
    public Rectangle(string color, double width, double length) : base(color)
    {
        _length = length;
        _width = width;
        
    }
    public override double GetPerimeter()
    {
        return 2 * (_width + _length);
    }
    public override double GetArea()
    {
        return _length * _width;
    }

    
    
   
}