using System;

namespace zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //4.Напишете израз, който да проверява дали третия бит на дадено число е 1 или 0. 

            int numberBit = int.Parse(Console.ReadLine());
            int numberByEight = numberBit & 8;
            
            Console.WriteLine(numberByEight);
        }
    }
}
