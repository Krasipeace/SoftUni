using System; //arabic to roman
using System.Collections.Generic;
using System.Text;

namespace Problem_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter arabic number: ");
            int number = int.Parse(Console.ReadLine());

            Dictionary<int, string> arabicToRoman = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };

            StringBuilder roman = new StringBuilder();

            foreach (var item in arabicToRoman)
            {
                while (number >= item.Key)
                {
                    roman.Append(item.Value);
                    number -= item.Key;
                }
            }

            Console.WriteLine(roman.ToString());

        }
    }
}
