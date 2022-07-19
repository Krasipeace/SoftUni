using System; // HEX >>> DEC
using System.Numerics;
using System.Globalization;

namespace Problem_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Hexadecimal Number: ");
            string hex = Console.ReadLine();

            if (hex == "0" || hex == "0x0")
            {
                Console.WriteLine("Decimal Number = 0");

                return;
            }

            int number = int.Parse(hex, NumberStyles.HexNumber);

            Console.WriteLine($"Decimal number: {number}");

        }
    }
}
