using System;
using System.Linq;

//Read an array of strings and take only words, whose length is an even number. Print each word on a new line.
namespace _4._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Where(wrd => wrd.Length % 2 == 0).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
