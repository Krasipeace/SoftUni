using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Random randomList = new Random();

            for (int i = 0; i < inputList.Count; i++)
            {
                int randomWord = randomList.Next(inputList.Count);
                string a = inputList[randomWord];
                string b = inputList[i];

                inputList[randomWord] = b;
                inputList[i] = a;
            }
            Console.WriteLine(String.Join(Environment.NewLine, inputList));
        }
    }
}
