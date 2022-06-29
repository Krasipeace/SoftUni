using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    internal class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        string Content { get; set; }
        string Author { get; set; }
        string Title { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int command = int.Parse(Console.ReadLine());

            for (int i = 0; i < command; i++)
            {
                List<string> articleInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                Article article = new Article(articleInput[0], articleInput[1], articleInput[2]);

                articles.Add(article);
            }

            string sorting = Console.ReadLine();
            switch (sorting)
            {
                case "title":
                    articles.OrderByDescending(big => big.Title).ToList();
                    break;
                case "content":
                    articles.OrderByDescending(big => big.Content).ToList();
                    break;
                case "author":
                    articles.OrderByDescending(big => big.Author).ToList();
                    break;
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));

        }
    }
}