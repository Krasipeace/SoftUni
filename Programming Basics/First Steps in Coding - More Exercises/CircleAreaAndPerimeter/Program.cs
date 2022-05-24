using System;

namespace CircleAreaAndPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            //въвеждане на радиус
            double radius = double.Parse(Console.ReadLine());
            //изчисления
            double area = radius * radius * Math.PI;
            double perimeter = radius * 2 * Math.PI;
            Console.WriteLine("{0:f2}", area);
            Console.WriteLine("{0:f2}", perimeter);
        }
    }
}