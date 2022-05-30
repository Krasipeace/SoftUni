using System;

namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2.Напишете програма, която показва знака (+ или -) от произведението на три реални числа, без да го пресмята.
            //Използвайте последователност от if оператори.
            
            Console.Write("Enter number 1: ");
            double numberOne = double.Parse(Console.ReadLine());
            Console.Write("Enter number 2: ");
            double numberTwo = double.Parse(Console.ReadLine());
            Console.Write("Enter number 3: ");
            double numberThree = double.Parse(Console.ReadLine());

            if (numberOne == 0 || numberTwo == 0 || numberThree == 0)
            {
                Console.WriteLine("Multiply equals: 0");
            }
            if ((numberOne < 0 && numberTwo > 0 && numberThree > 0) || (numberTwo < 0 && numberOne > 0 && numberThree > 0) 
                || (numberThree < 0 && numberOne > 0 && numberTwo > 0) || (numberOne < 0 && numberTwo < 0 && numberThree < 0))
            {
                Console.WriteLine("-");
            }
            else if ((numberOne < 0 && numberTwo < 0 && numberThree > 0) || (numberOne < 0 && numberThree < 0 && numberTwo > 0) 
                || (numberTwo < 0 && numberThree < 0 && numberOne > 0) || (numberOne > 0 && numberTwo > 0 && numberThree > 0))
            {
                Console.WriteLine("+");
            }
        }
    }
}
