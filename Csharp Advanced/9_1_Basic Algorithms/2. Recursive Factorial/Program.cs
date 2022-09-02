using System;

namespace _2._Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(number));
        }

        private static ulong Factorial(ulong number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
