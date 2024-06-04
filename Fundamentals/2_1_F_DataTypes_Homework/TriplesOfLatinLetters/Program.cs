using System;

namespace TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (char i = 'a'; i < 'a' + input; i++)
            {
                for (char j = 'a'; j < 'a' + input; j++)
                {
                    for (char k = 'a'; k < 'a' + input; k++)
                    {
                        Console.WriteLine($"{i}{j}{k}");
                    }
                }
            }
        }
    }
}
