using System;

namespace Problem_5 //right-angled triangle, find hypotenuse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter side A: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter side B: ");
            double sideB = double.Parse(Console.ReadLine());

            double hypotenuse = Math.Sqrt(sideA * sideA + sideB * sideB);

            Console.WriteLine($"Hypotenuse is: {hypotenuse}");
        }
    }
}
