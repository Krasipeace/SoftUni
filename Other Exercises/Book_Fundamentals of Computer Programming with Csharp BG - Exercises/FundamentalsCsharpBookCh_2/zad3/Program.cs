using System;

namespace zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            //3.      Напишете програма, която изчислява вярно променливи с плаваща запетая с точност до 0.000001.          
            decimal numberOne = decimal.Parse(Console.ReadLine());
            decimal numberTwo = decimal.Parse(Console.ReadLine());
            decimal sumNumbers = numberOne + numberTwo;

            Console.WriteLine("{0:f6}", sumNumbers);

        }
    }
}