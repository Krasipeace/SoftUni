using System;
using System.Collections.Generic;

namespace Problem_13 //task 15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> wordsDictionary = new Dictionary<string, string>();

            wordsDictionary.Add(".NET", "platform for applications from Microsoft");
            wordsDictionary.Add("CLR", "managed execution environment for .NET");
            wordsDictionary.Add("namespace", "hierarchical organization of classes");

            Console.Write("Search for word: ");
            string searchWord = Console.ReadLine();

            foreach (var item in wordsDictionary)
            {
                if (item.Key == searchWord)
                { 
                Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }

        }
    }
}
