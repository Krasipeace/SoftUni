using System;

namespace SquareFrame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string plus = "+";
            string minus = "-";
            string interval = " ";
            string line = "|";

            int choice = int.Parse(Console.ReadLine());  
            Console.Write(plus + interval);
            for (int i = 1; i <= choice - 2; i++)
            {
                Console.Write(minus + interval);
            }
            Console.WriteLine(plus);
            for (int j = 1; j <= choice - 2 ; j++)
            {
                Console.Write(line + interval);
                for (int i = 1; i <= choice - 2; i++)
                {
                    Console.Write(minus + interval);
                }
                Console.WriteLine(line);
            }
            Console.Write(plus + interval);
            for (int i = 1; i <= choice - 2; i++)
            {
                Console.Write(minus + interval);
            }
            Console.WriteLine(plus);
        }
    }
}

