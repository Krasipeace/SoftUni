using System;

namespace zad8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //8.Напишете програма, която чете пет числа от конзолата и отпечатва най-голямото от тях.
            Console.Write("Enter 1st number: ");
            int numberOne = int.Parse(Console.ReadLine());

            Console.Write("Enter 2nd number: ");
            int numberTwo = int.Parse(Console.ReadLine());

            Console.Write("Enter 3rd number: ");
            int numberThree = int.Parse(Console.ReadLine());

            Console.Write("Enter 4th number: ");
            int numberFour = int.Parse(Console.ReadLine());

            Console.Write("Enter 5th number: ");
            int numberFive = int.Parse(Console.ReadLine());

            if (numberOne > numberTwo && numberOne > numberThree && numberOne > numberFour && numberOne > numberFive)
            {
                Console.WriteLine("The Greater number is " + numberOne);
            }
            else if (numberTwo > numberOne && numberTwo > numberThree && numberTwo > numberFour && numberTwo > numberFive)
            {
                Console.WriteLine("The Greater number is " + numberTwo);
            }
            else if (numberThree > numberOne && numberThree > numberTwo && numberThree > numberFour && numberThree > numberFive)
            {
                Console.WriteLine("The Greater number is " + numberThree);
            }
            else if (numberFour > numberOne && numberFour > numberTwo && numberFour > numberThree && numberFour > numberFive)
            {
                Console.WriteLine("The Greater number is " + numberFour);
            }
            else if (numberFive > numberOne && numberFive > numberTwo && numberFive > numberThree && numberFive > numberFour)
            {
                Console.WriteLine("The Greater number is " + numberFive);
            }
            else
            {
                Console.WriteLine("The coder is noob and didnt find solution to this problem yet... :D");
            }

        }
    }
}
