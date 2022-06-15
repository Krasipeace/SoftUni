using System;
using System.Collections.Generic;

namespace _4.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int listRange = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < listRange; i++)
            {
                string currentProduct = Console.ReadLine();
                products.Add(currentProduct);
            }

            products.Sort();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
