using System; //count for In/in in text
using System.Text.RegularExpressions;

namespace Problem_3 //task 5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any text:");
            string text = Console.ReadLine();

            string pattern = @"in|In";

            MatchCollection matches = Regex.Matches(text, pattern);
            int counter = 0;

            for (int i = 0; i < matches.Count; i++)
            {
                counter++;
            }

            if (counter >= 1)
            {
                Console.WriteLine($"In/in is counted {counter} times in the text");
            }
            else
            {
                Console.WriteLine("In/in doesnt contains in the text!");
            }
        }
    }
}
