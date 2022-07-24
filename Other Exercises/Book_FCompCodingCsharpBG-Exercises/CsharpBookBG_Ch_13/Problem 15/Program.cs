using System;
using System.Text;

namespace Problem_15 //task 17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter first date (DD.MM.YYYY): ");
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
                      
            Console.Write("Enter second date (DD.MM.YYYY): ");
            DateTime secondDate = DateTime.Parse(Console.ReadLine());
            
            int days = secondDate.Day - firstDate.Day;

            Console.WriteLine($"Distance {days} days.");

        }
    }
}
