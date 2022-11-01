using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        private static List<Person> people;
        private static List<Product> products;
        static void Main(string[] args)
        {
            people = new List<Person>();
            products = new List<Product>();

            List<string> buyers = new List<string>(Console.ReadLine().Split(";").ToList());
            List<string> productsToBuy = new List<string>(Console.ReadLine().Split(";").ToList());

            foreach (var input in from buyer in buyers
                                  let input = buyer.Split("=").ToList()
                                  select input)
            {
                try
                {
                    people.Add(new Person(input[0], decimal.Parse(input[1])));
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);

                    return;
                }
            }

            foreach (var input in from item in productsToBuy
                                  let input = item.Split("=").ToList()
                                  select input)
            {
                try
                {
                    products.Add(new Product(input[0], decimal.Parse(input[1])));
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);

                    return;
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                string buyerName = tokens[0];
                string productName = tokens[1];

                try
                {
                    Person buyer = people.Find(p => p.Name == buyerName);
                    buyer.BuyProduct(products.Find(p => p.Name == productName));
                }
                catch (InvalidOperationException op)
                {
                    Console.WriteLine(op.Message);                  
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}
