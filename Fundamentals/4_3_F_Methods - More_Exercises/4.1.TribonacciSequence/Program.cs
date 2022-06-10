using System;

namespace _4._1.TribonacciSequence  //second attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                System.Environment.Exit(0);
            }
            PrintTribo(number);
        }
        static void PrintTribo(int number)
        {
            int[] arrTrib = new int[number];
            
            arrTrib[0] = arrTrib[1] = 1;          
            arrTrib[2] = 2;
            if (number > 3)
            {
                for (int i = 3; i < number; i++)
                {
                    arrTrib[i] = arrTrib[i - 1] + arrTrib[i - 2] + arrTrib[i - 3];
                }

                for (int i = 0; i < number; i++)
                {
                    Console.Write($"{arrTrib[i]} ");
                }
                return;
            }
            if (number == 3)
            {
                Console.Write("1 1 2");
                return;
            }
            if (number == 2)
            {
                Console.Write("1 1");
                return;
            }
            else
            {
                Console.Write("1");
                return;
            }


        }
    }
}
