using System; //count letters in words from text
using System.Collections.Generic;
using System.Linq;

namespace Problem_20 //task 22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();          

            Dictionary<char, int> letters = text.Replace(" ", string.Empty).GroupBy(c => c).OrderBy(a => a.Key)
                                            .ToDictionary(gr => gr.Key, gr => gr.Count());
            
            Console.WriteLine();          

            foreach (var letter in letters.Keys)
            {
                Console.WriteLine($"{letter} : {letters[letter]}");
            }
        }
    }
}
