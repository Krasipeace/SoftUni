using System;

namespace zad7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //7.Напишете програма, която чете пет числа и отпечатва тяхната сума. При невалидно въведено число да се подкани потребителя да въведе друго число.
            Console.WriteLine("Enter 5 numbers and sums them up");

            Console.Write("Enter 1st number: ");
            string numberOneCheck = Console.ReadLine();
            int numberOne;
            bool ParseOne = int.TryParse(numberOneCheck, out numberOne);
            Console.WriteLine(ParseOne ? "The number is valid." : "Invalid Number!");           //is this condition true ? yes : no
            if (ParseOne == false)
            {
                Console.Write("Enter a valid 1st number again: ");
                numberOneCheck = Console.ReadLine();
                ParseOne = int.TryParse(numberOneCheck, out numberOne);
                Console.WriteLine(ParseOne ? "The number is valid." : "Invalid Number!");
            }

            Console.Write("Enter 2nd number: ");
            string numberTwoCheck = Console.ReadLine();
            int numberTwo;
            bool ParseTwo = int.TryParse(numberTwoCheck, out numberTwo);
            Console.WriteLine(ParseTwo ? "The number is valid." : "Invalid Number!");
            if (ParseTwo == false)
            {
                Console.Write("Enter a valid 2nd number again: ");
                numberTwoCheck = Console.ReadLine();
                ParseOne = int.TryParse(numberTwoCheck, out numberTwo);
                Console.WriteLine(ParseTwo ? "The number is valid." : "Invalid Number!");
            }

            Console.Write("Enter 3rd number: ");
            string numberThreeCheck = Console.ReadLine();
            int numberThree;
            bool ParseThree = int.TryParse(numberThreeCheck, out numberThree);
            Console.WriteLine(ParseThree ? "The number is valid." : "Invalid Number!");
            if (ParseThree == false)
            {
                Console.Write("Enter a valid 3rd number again: ");
                numberThreeCheck = Console.ReadLine();
                ParseThree = int.TryParse(numberThreeCheck, out numberThree);
                Console.WriteLine(ParseThree ? "The number is valid." : "Invalid Number!");
            }

            Console.Write("Enter 4th number: ");
            string numberFourCheck = Console.ReadLine();
            int numberFour;
            bool ParseFour = int.TryParse(numberFourCheck, out numberFour);
            Console.WriteLine(ParseFour ? "The number is valid." : "Invalid Number!");
            if (ParseFour == false)
            {
                Console.Write("Enter a valid 4th number again: ");
                numberFourCheck = Console.ReadLine();
                ParseFour = int.TryParse(numberFourCheck, out numberFour);
                Console.WriteLine(ParseFour ? "The number is valid." : "Invalid Number!");
            }

            Console.Write("Enter 5th number: ");
            string numberFiveCheck = Console.ReadLine();
            int numberFive;
            bool ParseFive = int.TryParse(numberFiveCheck, out numberFive);
            Console.WriteLine(ParseFive ? "The number is valid." : "Invalid Number!");
            if (ParseFive == false)
            {
                Console.Write("Enter a valid 5th number again: ");
                numberFiveCheck = Console.ReadLine();
                ParseFive = int.TryParse(numberFiveCheck, out numberFive);
                Console.WriteLine(ParseFive ? "The number is valid." : "Invalid Number!");
            }

            int sumNumbers = numberOne + numberTwo + numberThree + numberFour + numberFive;
            Console.WriteLine("The Sum of the valid numbers is: " + sumNumbers);     
        }
    }
}
