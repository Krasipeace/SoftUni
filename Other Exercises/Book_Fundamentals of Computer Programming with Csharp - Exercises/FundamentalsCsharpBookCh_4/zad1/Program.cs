using System;

namespace zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Program sums up 3 numbers");

            Console.Write("Enter 1st number: ");
            int numberOne = int.Parse(Console.ReadLine());

            Console.Write("Enter 2nd number: ");
            int numberTwo = int.Parse(Console.ReadLine());

            Console.Write("Enter 3rd number: ");
            int numberThree = int.Parse(Console.ReadLine());

            int Sum = numberOne + numberTwo + numberThree;
            Console.WriteLine("The sum of the numbers is: " + Sum);
        }
    }
}
