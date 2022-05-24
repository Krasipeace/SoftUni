using System;

namespace Rectangleof10stars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char star = '*';
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.Write(star);
                }
                Console.WriteLine(star);
            }
        }
    }
}
