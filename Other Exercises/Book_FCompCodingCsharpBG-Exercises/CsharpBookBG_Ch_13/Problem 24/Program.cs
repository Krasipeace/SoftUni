using System;
using System.Text.RegularExpressions;

namespace Problem_24 //task 26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter HTML text: ");
            string text = Console.ReadLine();

            string pattern = @"<([\w\-/]+)( +[\w\-]+(=(('[^']*')|(\""[^\""]*\"")))?)* *>";          

            string title = string.Empty;
            Match matchTitle = Regex.Match(text, @"<title>\s*(.+?)\s*</title>");
            if (matchTitle.Success)
            {
                title = matchTitle.Groups[1].Value;
            }
            Console.WriteLine($"Title: {title} ");



            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.Multiline);

            string newText = Regex.Replace(text, pattern, string.Empty);

            Console.WriteLine("Body: ");
            Console.WriteLine(newText);

//unfinished
        }
    }
}
