using System;

namespace Problem_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generation of random advertisement message");
            Console.WriteLine();

            string[] cities = { "Sofia", "Plovdiv", "Varna", "Bourgas", "Rousse" };
            string[] firstName = { "Diana", "Petya", "Stela", "Elena", "Katya" };
            string[] lastName = { "Ivanova", "Petrova", "Kirova" };
            string[] feel = { "Now I feel better.", "I managed to change.", "It made a miracle.", "I can’t believe it, but I am feeling greatnow.", "You should try it too. I am very satisfied." };
            string[] phrase = { "The product is excellent.", "This is a great product.", "I use this products all the time.", "This is the best product from this category." };

            Random random = new Random();

            string randomCity = cities[random.Next(cities.Length)];
            string randomFirstName = firstName[random.Next(firstName.Length)];
            string randomLastName = lastName[random.Next(lastName.Length)];
            string randomFeel = feel[random.Next(feel.Length)];
            string randomPhrase = phrase[random.Next(phrase.Length)];

            string message = $"{randomPhrase} {randomFeel} -- {randomFirstName} {randomLastName}, {randomCity}.";
            Console.WriteLine(message);
        }
    }
}
