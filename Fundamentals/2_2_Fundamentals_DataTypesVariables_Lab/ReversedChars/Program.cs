using System;

namespace ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            char three = char.Parse(Console.ReadLine());
            Console.Write($"{three} {two} {one}");
        }
    }
}
