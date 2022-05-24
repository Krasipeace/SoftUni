using System;

namespace OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            int counter = 0;
            bool isBookFound = false;
            string nextBook = Console.ReadLine();
            while (nextBook != "No More Books")
            {
                if (nextBook == favoriteBook)
                {
                    isBookFound = true;
                    break;
                }
                counter += 1;
                nextBook = Console.ReadLine();
            }
            if (isBookFound)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
