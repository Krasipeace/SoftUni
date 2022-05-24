using System;

namespace TriangleOfDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char dollar = '$';
            string interval = " ";
            int choice = int.Parse(Console.ReadLine());
            for (int i = 1; i <= choice; i++)
            {
                for (int j = 1; j <= i - 1; j++)
                {
                    Console.Write(dollar + interval);
                }
                Console.WriteLine(dollar);
            }
        }
    }
}
