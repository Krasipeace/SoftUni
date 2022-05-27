using System;

namespace SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int number = 1; number <= limit; number++)
            {
                if (number % 2 != 0)
                {
                    Console.WriteLine(number);
                    sum += number;
                }
               else
               {
                   limit++;
               }                
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
