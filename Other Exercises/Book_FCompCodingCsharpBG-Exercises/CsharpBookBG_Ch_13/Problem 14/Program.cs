using System;
using System.Text;

namespace Problem_14 //task 16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            Console.WriteLine();

            StringBuilder toURL = new StringBuilder(text);

            toURL.Replace("<a href=", "[URL=");
            toURL.Replace("\">", "\"]");
            toURL.Replace("</a>", "[/URL]");

            Console.WriteLine(toURL.ToString());
        }
    }
}
