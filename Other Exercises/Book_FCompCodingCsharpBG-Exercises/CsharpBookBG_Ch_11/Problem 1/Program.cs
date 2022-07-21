using System;  //leap year

namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter any year (YYYY): ");
            int input = int.Parse(Console.ReadLine());

            if (DateTime.IsLeapYear(input))
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
