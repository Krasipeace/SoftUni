using System;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            while (sum < number)
            {
                int input = int.Parse(Console.ReadLine());
                sum += input;
            }
            Console.WriteLine(sum);
        }
    }
}
