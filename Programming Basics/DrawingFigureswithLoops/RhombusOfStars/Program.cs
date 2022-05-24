using System;

namespace RhombusOfStars  
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string star = "*";
            string interval = " "; 
            int choice = int.Parse(Console.ReadLine());
            for (int i = 1; i <= choice; i++)
            {
                for (int j = 1; j <= choice - i; j++)
                {
                    Console.Write(interval);
                }
                Console.Write(star);
                for (int j = 1; j <= i - 1; j++)
                {
                    Console.Write(interval + star);
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= choice - 1; i++)
            {
                for (int j = 1; j <= i - 1; j++)
                {
                    Console.Write(interval);
                }
                for (int j = 1; j <= choice - i; j++)
                {
                    Console.Write(interval + star);
                }
                Console.WriteLine();
            }
        }
    }
}
