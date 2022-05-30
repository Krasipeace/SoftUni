using System;

namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2. Напишете булев израз, който да проверява дали дадено цяло число се дели на 5 и на 7 без остатък.

            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            bool isFive = false;
            bool isSeven = false;

            if (number % 5 == 0)
            {
                isFive = true;
            }
            if (number % 7 == 0)
            {
                isSeven = true;
            }
            Console.Write("is it divided both into 5 and 7: ");
            Console.WriteLine(isFive & isSeven);
        }
    }
}
