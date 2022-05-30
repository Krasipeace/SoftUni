using System;

namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Perimeter and area of a Circle.");
            Console.Write("Enter radius of a circle: ");
            double radius = double.Parse(Console.ReadLine());

            double perimeter = 2 * radius * Math.PI;
            double area = radius * radius * Math.PI;

            Console.WriteLine("Perimeter of the circle is: " + perimeter);
            Console.WriteLine("Area of the circle is: " + area);
        }
    }
}
