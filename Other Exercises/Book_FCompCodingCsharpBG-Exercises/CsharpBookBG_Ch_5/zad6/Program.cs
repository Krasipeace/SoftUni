using System;

namespace zad6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Напишете програма, която при въвеждане на коефициентите (a, b и c) на квадратно уравнение: ax2+bx+c, изчислява и извежда неговите реални корени (ако има такива).
            //Квадратните уравнения могат да имат 0, 1 или 2 реални корена.

            Console.WriteLine("Calculate roots of ax^2+bx+c=0, if has any roots.");
            Console.Write("Enter value of a: ");
            double numberA = double.Parse(Console.ReadLine());
            Console.Write("Enter value of b: ");
            double numberB = double.Parse(Console.ReadLine());
            Console.Write("Enter value of c: ");
            double numberC = double.Parse(Console.ReadLine());

            double discriminant = Math.Sqrt(numberB * numberB - 4 * numberA * numberC);

            if (discriminant == 0)
            {
                double rootX = -numberB / 2 * numberA;
                Console.WriteLine("The Equation has 1 real root and value of the root is: " + rootX);
            }
            else if (discriminant > 0)
            {
                double rootOne = (-numberB + discriminant) / 2 * numberA;
                double rootTwo = (-numberB - discriminant) / 2 * numberA;
                Console.WriteLine("The Equation has 2 real roots and their values are: " + rootOne + " " + rootTwo);
            }
            else
            {
                Console.WriteLine("The Equation has no real roots!(D<0)");
            }
        }
    }
}
