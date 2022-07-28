using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Santa_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @".*?@(?<name>[A-Za-z]+)+(?:[^@!:>-]*)!(?<behavior>[G|N])!";  //use regex after decrypting
            var outputList = new List<string>();

            int key = int.Parse(Console.ReadLine());         // decrypted symbols = current-key symbols

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "end")
                {
                    break;
                }

                StringBuilder output = new StringBuilder();

                for (var i = 0; i < input.Length; i++)
                {
                    output.Append((char)(input[i] - key));  //decrypting
                }

                string message = output.ToString();
                output.Clear();
                
                string name = Regex.Match(message, pattern).Groups["name"].Value;  //using pattern after decrypting
                string behavior = Regex.Match(message, pattern).Groups["behavior"].Value;

                if (behavior == "G")
                {
                    outputList.Add(name);                   //if good add to outputList
                }

                input = Console.ReadLine();
            }

            foreach (var kidName in outputList)             //print all good kids
            {
                Console.WriteLine(kidName);
            }
        }
    }
}
