using System;
using System.Linq;
using System.Text;

namespace _6._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();

            input.Distinct().Select(currChar => currChar.ToString()).ToList()
                .ForEach(currChar =>
            {
                while (input.Contains(currChar + currChar))
                {
                    input = input.Replace(currChar + currChar, currChar);
                }
            }
                        );
            output.AppendLine(input);

            Console.WriteLine(output.ToString());
        }
    }
}
