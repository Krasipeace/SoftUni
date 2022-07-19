using System;

namespace Problem_5 //HEX to BIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a hexadecimal number: ");
            string hex = Console.ReadLine();

            string number = Convert.ToString(Convert.ToInt32(hex, 16), 2);

            Console.WriteLine($"Decimal number: {number}");

        }
    }
}
