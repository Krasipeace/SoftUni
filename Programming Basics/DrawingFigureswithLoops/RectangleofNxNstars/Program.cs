using System;

namespace RectangleofNxNstars
{
        internal class Program
        {
            static void Main(string[] args)
            {
                char star = '*';
                int choice = int.Parse(Console.ReadLine());
                for (int i = 1; i <= choice; i++)
                {
                    for (int j = 1; j <= choice-1; j++)
                    {
                        Console.Write(star);
                    }
                    Console.WriteLine(star);
                }
            }
        }
}


