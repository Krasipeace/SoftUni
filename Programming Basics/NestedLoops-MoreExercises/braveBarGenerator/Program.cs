using System;

namespace _04._Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int number;
            int count = 0;
            int digit;

            for (int i = numberOne; i <= numberTwo; i++)
            {
                number = i;
                while (i > 999)
                {
                    count++;

                    digit = number % 10;
                    if (digit % 2 != 0)
                    {
                        Console.Write($"{i} "); 
                    }
                    else
                    {
                        break;
                    }
                    number /= 1000; //прпецаква задачата
                    if (i == numberTwo)
                    {
                        return;
                    }
                }
                count = 0;
            }
        }
    }
}
