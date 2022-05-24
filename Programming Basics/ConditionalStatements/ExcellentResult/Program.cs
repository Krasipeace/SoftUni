using System;

namespace ExcellentResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade >= 5.50 && grade <= 6.00)
            {
                Console.WriteLine("Excellent!");
            }
            //else
            //{
            //    Console.WriteLine("Enter a valid grade!");
            //}
        }
    }
}