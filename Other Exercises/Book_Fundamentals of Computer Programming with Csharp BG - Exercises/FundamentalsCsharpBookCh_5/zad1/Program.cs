using System;

namespace zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Да се напише if-конструкция, която проверява стойността на две целочислени променливи и разменя техните стойности,
            //ако стойността на първата променлива е по-голяма от втората.
            Console.WriteLine("Enter 2 numbers and exchange their values, if number 1 > number 2.");

            Console.Write("Enter number one: ");
            int numberOne = int.Parse(Console.ReadLine());
            Console.Write("Enter number two: ");
            int numberTwo = int.Parse(Console.ReadLine());

            if (numberOne > numberTwo)
            {
                int numberX = numberOne;
                numberOne = numberTwo;
                numberTwo = numberX;
                Console.WriteLine("Now number one is: " + numberOne + " and number two is: " + numberTwo);
            }
            else
            {
                Console.WriteLine("No exchange of values has happened, because " + numberOne +  " =< " + numberTwo + "!");
            }


        }
    }
}
