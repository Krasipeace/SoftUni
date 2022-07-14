using System;
using System.Linq;

namespace _5._DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] digits = input
                .Where(ch => char.IsDigit(ch))
                .ToArray();

            char[] letters = input
                .Where(ch => char.IsLetter(ch))
                .ToArray();

            char[] others = input
                .Where(ch => !char.IsLetterOrDigit(ch))
                .ToArray();

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
