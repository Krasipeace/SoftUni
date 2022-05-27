using System;

namespace CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            char three = char.Parse(Console.ReadLine());
            string ones = char.ToString(one);
            string twos = char.ToString(two);
            string threes = char.ToString(three);
            Console.Write($"{one}{two}{three}");
        }
    }
}
