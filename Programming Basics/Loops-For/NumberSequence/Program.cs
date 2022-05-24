using System;

namespace NumberSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int smallNumber = int.MaxValue;
            int bigNumber = int.MinValue;
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < smallNumber)
                {
                    smallNumber = num;
                }
                if (num > bigNumber)
                {
                    bigNumber = num;
                }
            }
            Console.WriteLine($"Max number: {bigNumber}");
            Console.WriteLine($"Min number: {smallNumber}");
        }
    }
}
