using System;
using System.Numerics;

namespace _2.CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            if (CloseToCenterPoint(x1, y1) <= CloseToCenterPoint(x2, y2))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }

        }

        static double CloseToCenterPoint(double x, double y)
        {
            double checkX = x;
            double checkY = y;

            return Math.Sqrt(Math.Abs((Math.Pow(checkX, 2)) + Math.Pow(checkY, 2)));    //хипотенуза

        }
    }
}
