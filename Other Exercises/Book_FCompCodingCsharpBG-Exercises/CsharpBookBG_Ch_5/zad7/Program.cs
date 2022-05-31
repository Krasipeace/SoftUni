using System;

namespace zad7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //7.Напишете програма, която намира най-голямото по стойност число измежду дадени 5 числа.

            Console.WriteLine("Find the Greater number between 5 numbers.");
            Console.Write("Enter number one: ");
            double numberOne = double.Parse(Console.ReadLine());
            Console.Write("Enter number two: ");
            double numberTwo = double.Parse(Console.ReadLine());
            Console.Write("Enter number three: ");
            double numberThree = double.Parse(Console.ReadLine());
            Console.Write("Enter number four: ");
            double numberFour = double.Parse(Console.ReadLine());
            Console.Write("Enter number five: ");
            double numberFive = double.Parse(Console.ReadLine());

            if ((numberOne > numberTwo) && (numberOne > numberThree) && (numberOne > numberFour) && (numberOne > numberFive))
            {
                Console.WriteLine("The Greater number between them is: " + numberOne);
            }
            if ((numberTwo > numberOne) && (numberTwo > numberThree) && (numberTwo > numberFour) && (numberTwo > numberFive))
            {
                Console.WriteLine("The Greater nuumber between them is: " + numberTwo);
            }
            if ((numberThree > numberOne) && (numberThree > numberTwo) && (numberThree > numberFour) && (numberThree > numberFive))
            {
                Console.WriteLine("The Greater number between them is: " + numberThree);
            }
            if ((numberFour > numberOne) && (numberFour > numberTwo) && (numberFour > numberThree) && (numberFour > numberFive))
            {
                Console.WriteLine("The Greater number betweem them is: " + numberFour);
            }
            if ((numberFive > numberOne) && (numberFive > numberTwo) && (numberFive > numberThree) && (numberFive > numberFour))
            {
                Console.WriteLine("The Greater number between them is: " + numberFive);
            }
        }
    }
}
