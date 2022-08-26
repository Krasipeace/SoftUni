using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> ckecker = n => n[0] == n.ToUpper()[0]; //checks for UpperCase words

            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(word => ckecker(word)).ToArray();

            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }
    }
}