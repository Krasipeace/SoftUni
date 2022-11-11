using System;

namespace _4.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];
                int number = 0;

                try
                {
                    number = int.Parse(current);
                    sum += number;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{current}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{current}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{current}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
