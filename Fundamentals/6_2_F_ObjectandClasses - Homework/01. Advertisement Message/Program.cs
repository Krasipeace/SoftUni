using System;
using System.Collections.Generic;

namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string>() { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            List<string> events = new List<string>() { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            List<string> authors = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random randomPhrases = new Random();
            Random randomEvents = new Random();
            Random randomAuthors = new Random();
            Random randomCities = new Random();

            int numOfAdvertises = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfAdvertises; i++)
            {
                int randomPhrase = randomPhrases.Next(phrases.Count);
                int randomEvent = randomEvents.Next(events.Count);
                int randomAuthor = randomAuthors.Next(authors.Count);
                int randomCity = randomCities.Next(cities.Count);

                Console.WriteLine($"{phrases[randomPhrase]} {events[randomEvent]} {authors[randomAuthor]} – {cities[randomCity]}.");
            }
        }
    }
}
