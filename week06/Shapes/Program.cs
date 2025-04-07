using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Shape mySquare = new Square("Red", 4);
        Shape myRectangle = new Rectangle("Blue", 4, 5);
        Shape myCircle = new Circle("Green", 3);
        Shape myTriangle = new Triangle("Purple",3,4,5);
        Shape myHexagon = new Hexagon("Yellow", 6);

        
        List<Shape> shapes = new List<Shape> { mySquare, myRectangle, myCircle, myTriangle, myHexagon };

        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}\n");
            Console.WriteLine($"Shape Perimeter: {shape.GetPerimeter()}\n"); 
        }
    }
}