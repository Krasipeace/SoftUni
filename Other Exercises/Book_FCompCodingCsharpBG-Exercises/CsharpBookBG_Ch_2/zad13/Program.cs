using System;

namespace zad13
{
    class Program
    {
        static void Main(string[] args)
        {
            //13.Декларирайте две променливи от тип int. Задайте им стойности съответно 5 и 10. Разменете стойностите им и ги отпечатайте.
            int numberFive = 5;
            int numberTen = 10;
            Console.WriteLine("First number is: " + numberFive);
            Console.WriteLine("Second number is: " + numberTen);
            int exchangeNumber = numberFive;
            numberFive = numberTen;
            numberTen = exchangeNumber;
            Console.WriteLine("First number is: " + numberFive);
            Console.WriteLine("Second number is: " + numberTen);
        }
    }
}