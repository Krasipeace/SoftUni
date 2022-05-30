using System;

namespace zad9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //9.Напишете програма, която чете коефициентите a, b и c от конзолата и решава уравнението: ax2+bx+c=0.
            //Програмата трябва да принтира реалните решения на уравнението на конзолата. 

            Console.WriteLine("Enter a, b, c, and find the real answer of the equation ax^2+bx+c=0");

            Console.Write("Enter number a: ");
            double numberA = double.Parse(Console.ReadLine());

            Console.Write("Enter number b: ");
            double numberB = double.Parse(Console.ReadLine());

            Console.Write("Enter number c: ");
            double numberC = double.Parse(Console.ReadLine());

            double numberD = numberB * numberB - 4 * numberA * numberC;                  //дискриминанта за корените на уравнението D>0; D=0; D<0;

            if (numberD > 0)
            {
                double rootOne = (-numberB + Math.Sqrt(numberD) / (2 * numberA));
                double rootTwo = (-numberB - Math.Sqrt(numberD) / (2 * numberA));
                Console.WriteLine("The Two roots of the equation are: " + rootOne + " " + rootTwo);
            }
            else if (numberD == 0)
            {
                double root = (-numberB + Math.Sqrt(numberD) / (2 * numberA));
                Console.WriteLine("There is One real root of the equation: " + root);
            }
            else
            {
                Console.WriteLine("D<0 => The Equation doesnt have real roots");
            }
        }
    }
}
