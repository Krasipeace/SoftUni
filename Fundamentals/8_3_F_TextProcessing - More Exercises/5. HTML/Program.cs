using System;
using System.Collections.Generic;

namespace _5._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            string comment = Console.ReadLine();
            List<string> comments = new List<string>();

            while (true)
            {

                if (comment == "end of comments")
                {
                    break;
                }

                comments.Add(comment);

                comment = Console.ReadLine();
            }

            PrintResult(title, content, comments);
        }

        private static void PrintResult(string title, string content, List<string> comments)
        {
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {title}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"    {content}");
            Console.WriteLine("</article>");

            foreach (var eachComment in comments)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"    {eachComment}");
                Console.WriteLine("</div>");
            }
        }
    }
}
