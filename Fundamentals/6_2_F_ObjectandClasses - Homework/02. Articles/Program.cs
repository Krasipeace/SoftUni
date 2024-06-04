using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
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

        public void EditContent(string editContent)
        {
            Content = editContent;
        }
        public void ChangeAuthor(string changeAuthor)
        {
            Author = changeAuthor;
        }
        public void RenameTitle(string renameTitle)
        {
            Title = renameTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

        static void Main(string[] args)
        {
            List<string> articleInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Article article = new Article(articleInput[0], articleInput[1], articleInput[2]);

            int command = int.Parse(Console.ReadLine());

            for (int i = 0; i < command; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                switch (action)
                {
                    case "Edit":
                        article.EditContent(tokens[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(tokens[1]);
                        break;
                    case "Rename":
                        article.RenameTitle(tokens[1]);
                        break;
                }
            }

            Console.WriteLine(article);
        }
    }
}
