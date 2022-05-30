using System;

namespace zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3. Напишете израз, който да проверява дали третата цифра (отдясно на ляво) на дадено цяло число е 7.

            int numberByUser = int.Parse(Console.ReadLine());

            int numberByHundred = numberByUser / 100;
            //int numberByTen = numberByHundred % 10;
            int numberBySeven = numberByHundred << 3;

            Console.WriteLine(numberBySeven);
            Console.WriteLine(numberBySeven == 7);
        }
    }
}
