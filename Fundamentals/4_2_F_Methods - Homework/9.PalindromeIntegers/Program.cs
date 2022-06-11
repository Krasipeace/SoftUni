using System;

namespace _9.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while(input != "END")
            {
                bool checkForPalindrome = CheckInputPalindrome(input);
                Console.WriteLine(checkForPalindrome.ToString().ToLower());
                input = Console.ReadLine();
            }
        }

        private static bool CheckInputPalindrome(string input)
        {
            int number = int.Parse(input);

            if (number >= 0 && number <= 9)
            {
                return true;
            }

            if (input[0] == input[input.Length - 1])
            {
                return true;
            }
            return false;
        }
    }
}
