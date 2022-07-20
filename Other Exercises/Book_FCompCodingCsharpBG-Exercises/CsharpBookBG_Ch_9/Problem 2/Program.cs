using System;

namespace Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number 1: ");
            int numberOne = int.Parse(Console.ReadLine());
            Console.Write("Enter number 2: ");
            int numberTwo = int.Parse(Console.ReadLine());
            Console.Write("Enter number 3: ");
            int numberThree = int.Parse(Console.ReadLine());

            int result = 0;

            GetMax(numberOne, numberTwo, numberThree, result);
        }

        private static void GetMax(int numberOne, int numberTwo, int numberThree, int result)
        {
            result = Math.Max(numberOne, (Math.Max(numberTwo, numberThree)));

            Console.WriteLine($"Max number is: {result}");
        }

    }
}
