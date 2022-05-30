using System;

namespace zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Напишете програма, която намира най-голямото по стойност число, измежду три дадени числа.
            Console.WriteLine("Check 3 numbers and find the greater one of them");
            Console.Write("Enter number 1: ");
            int numberOne = int.Parse(Console.ReadLine());
            Console.Write("Enter number 2: ");
            int numberTwo = int.Parse(Console.ReadLine());
            Console.Write("Enter number 3: ");
            int numberThree = int.Parse(Console.ReadLine());

            if ((numberOne > numberTwo) && (numberOne > numberThree))
            {
                Console.WriteLine("The Greater number is " + numberOne);
            }
            else if ((numberTwo > numberOne) && (numberTwo > numberThree))
            {
                Console.WriteLine("The Greater number is " + numberTwo);
            }
            else if ((numberThree > numberOne) && (numberThree > numberTwo))
            {
                Console.WriteLine("The Greater number is " + numberThree);
            }
            else
            {
                Console.WriteLine("Enter 3 different numbers!");
            }
        }
    }
}
