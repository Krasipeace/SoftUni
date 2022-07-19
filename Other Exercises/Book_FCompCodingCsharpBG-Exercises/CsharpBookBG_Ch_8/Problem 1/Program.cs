using System;

namespace Problem_1
{ //dec to bin
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int remainder;
            string result = string.Empty;

            if (number == 0)
            {
                Console.WriteLine("Binary: 0");

                return;
            }

            while (number > 0)
            {
                remainder = number % 2;
                number /= 2;
                result = remainder.ToString() + result;
            }

            Console.WriteLine($"Binary: {result}");
        }
    }
}
