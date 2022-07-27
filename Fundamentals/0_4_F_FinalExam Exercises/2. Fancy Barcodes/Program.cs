using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+[A-Z][a-zA-Z\d]{4,}[A-Z]@#+";

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string currentBarcode = Console.ReadLine();

                if (Regex.IsMatch(currentBarcode, pattern))
                {
                    char[] digits = currentBarcode.Where(char.IsDigit).ToArray();

                    string barcodeGroup = digits.Length == 0 ? "00" : string.Join("", digits); // [4, 6] => 46

                    Console.WriteLine($"Product group: {barcodeGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
