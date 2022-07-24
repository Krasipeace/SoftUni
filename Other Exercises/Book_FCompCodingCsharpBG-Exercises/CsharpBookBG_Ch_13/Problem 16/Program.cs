using System;

namespace Problem_16 //task 18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter date and time (DD.MM.YYYY HH:mm:SS): ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());

            DateTime newTime = dateTime.AddHours(6.5);

            Console.WriteLine($"date and time after 6:30h.: {newTime}");
        }
    }
}
