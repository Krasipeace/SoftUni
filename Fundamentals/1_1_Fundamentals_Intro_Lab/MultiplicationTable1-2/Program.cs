using System;

namespace MultiplicationTable1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int sum = 0;
            if (numberTwo >= 11)
            {
                sum = number * numberTwo;
                Console.WriteLine($"{number} X {numberTwo} = {sum}");
            }
            for (int i = numberTwo; i <= 10; i++) 
            {
                sum = number * numberTwo;
                Console.WriteLine($"{number} X {numberTwo} = {sum}");
                numberTwo++;
            }
        }
    }
}
