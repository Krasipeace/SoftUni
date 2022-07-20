using System;

namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Last Digit of the number is: {GetDigitAsWord(number)}");           
        }

        private static string GetDigitAsWord(int number)
        {
            switch (number % 10)
            {
                case 0: 
                    return "zero";
                case 1: 
                    return "one";
                case 2: 
                    return "two";
                case 3: 
                    return "three";
                case 4: 
                    return "four";
                case 5: 
                    return "five";
                case 6: 
                    return "six";
                case 7: 
                    return "seven";
                case 8: 
                    return "eight";
                case 9: 
                    return "nine";
                default: 
                    return "error";
            }
        }
    }
}
