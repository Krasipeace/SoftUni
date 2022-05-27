using System;

namespace FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double absA = Math.Abs(a);
            double absB = Math.Abs(b);

            if (absA > absB)
            {
                if (absA - absB <= 0.000001)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
            else if (absA < absB)
            {
                if (absB - absA <= 0.000001)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }

        }
    }
}
