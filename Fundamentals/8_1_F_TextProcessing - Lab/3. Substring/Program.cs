using System;

namespace _3._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string removeChars = Console.ReadLine();
            string input = Console.ReadLine();

            while (input.Contains(removeChars))
            {
                int indexRemove = input.IndexOf(removeChars);
         
                input = input.Remove(indexRemove, removeChars.Length);
            }
            Console.WriteLine(input);
        }
    }
}
