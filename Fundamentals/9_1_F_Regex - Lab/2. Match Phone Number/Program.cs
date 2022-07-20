using System;
using System.Text.RegularExpressions;

namespace _2._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phoneNumbers = Console.ReadLine();
            string pattern = @"\+359([ -])2\1\d{3}\1\d{4}\b";

            MatchCollection matches = Regex.Matches(phoneNumbers, pattern);

            Console.Write(string.Join(", ", matches));
        }
    }
}
