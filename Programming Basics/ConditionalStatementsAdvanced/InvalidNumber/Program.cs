using System;

namespace InvalidNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool validNumber = number >= 100 && number <= 200 || number == 0;
            if (!validNumber)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
