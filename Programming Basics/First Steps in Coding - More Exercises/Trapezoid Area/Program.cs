using System;

namespace Trapezoid_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            //въвеждане страните и височината на трапеца
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            //пресмятaне лицето на трапеца
            double area = (b1 + b2) * h / 2.00;
            Console.WriteLine("{0:f2}", area);
        }
    }
}