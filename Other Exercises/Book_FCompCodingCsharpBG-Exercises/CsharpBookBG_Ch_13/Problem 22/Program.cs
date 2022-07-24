using System;  //"aaaaabbbbbcdddeeeedssaa" >>>>> "abcdedsa".
using System.Linq;
using System.Text;

namespace Problem_22 //task 24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter word: ");
            string input = Console.ReadLine();

            StringBuilder newText = new StringBuilder();
            input.Distinct().Select(currChar => currChar.ToString()).ToList().ForEach(currentChar =>
            {
                while (input.Contains(currentChar + currentChar))
                {
                    input = input.Replace(currentChar + currentChar, currentChar);
                }
            }
                                                                        );
            newText.AppendLine(input);

            Console.WriteLine(newText.ToString());
        }
    }
}
