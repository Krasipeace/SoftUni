using System;
using System.Linq;

namespace _1._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                var output = input.ToArray().Reverse();
                
                Console.WriteLine($"{input} = {string.Join("", output)}");

                input = Console.ReadLine();
            }
        }
    }
}

