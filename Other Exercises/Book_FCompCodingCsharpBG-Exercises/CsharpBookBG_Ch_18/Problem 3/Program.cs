using System; //Count words in text
using System.Collections.Generic;

namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");

            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> newList = new Dictionary<string, int>();

            foreach (var word in text)
            {
                if (newList.ContainsKey(word))
                {
                    newList[word]++;
                }
                else
                {
                    newList.Add(word, 1);
                }
            }

            foreach (var item in newList)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
