// Extended version with actual drawing
namespace Shapes
{
    using System;

    using Shapes.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(10);
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());
            circle.Drawing();

            Console.WriteLine();

            Rectangle rectangle = new Rectangle(10, 20);
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.Draw());
            rectangle.Drawing();
        }
    }
}
