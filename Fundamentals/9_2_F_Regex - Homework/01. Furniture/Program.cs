using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @">>(?<productType>[A-Za-z]+)<<(?<productPrice>[\d\.\d]+)!(?<productQuantity>\d+)";
                        
            List<string> products = new List<string>();
            double sum = 0.0;

            while (true)
            {
                if (input == "Purchase")
                {
                    break;
                }

                Match matchProducts = Regex.Match(input, pattern, RegexOptions.IgnoreCase);    

                if (matchProducts.Success)
                {
                    string productName = matchProducts.Groups["productType"].Value;
                    products.Add(productName);
                    double productPrice = double.Parse(matchProducts.Groups["productPrice"].Value);
                    int productQuantity = int.Parse(matchProducts.Groups["productQuantity"].Value);

                    sum += productPrice * productQuantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {sum:f2}");                            

        }
    }
}
