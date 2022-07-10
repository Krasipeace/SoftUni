using System;
using System.Collections.Generic;

namespace _5._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            AddPeople(people);

            AddProducts(products);

            BuyingProducts(people, products);

            PrintResult(people);
        }

        private static void AddPeople(List<Person> people)
        {
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string person in peopleInput)
            {
                string name = person.Split('=', StringSplitOptions.RemoveEmptyEntries)[0];
                double money = double.Parse(person.Split('=', StringSplitOptions.RemoveEmptyEntries)[1]);
                people.Add(new Person(name, money));
            }
        }

        private static void AddProducts(List<Product> products)
        {
            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string product in productsInput)
            {
                string name = product.Split('=', StringSplitOptions.RemoveEmptyEntries)[0];
                double price = double.Parse(product.Split('=', StringSplitOptions.RemoveEmptyEntries)[1]);
                products.Add(new Product(name, price));
            }
        }

        private static void BuyingProducts(List<Person> people, List<Product> products)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                string personsName = command.Split()[0];
                string productName = command.Split()[1];

                people.Find(currPerson => currPerson.Name == personsName).BuyProduct(products.Find(currProduct => currProduct.Name == productName));

                command = Console.ReadLine();
            }
        }

        private static void PrintResult(List<Person> people)
        {
            foreach (Person person in people)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> Bag { get; set; } = new List<string>();
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
        }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Price)
            {
                Bag.Add(product.Name);
                Money -= product.Price;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
