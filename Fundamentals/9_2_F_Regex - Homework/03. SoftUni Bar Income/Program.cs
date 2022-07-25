using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)[^|$%.]*\$";

            string input = Console.ReadLine();
            double totalIncome = 0.0;

            while (true)
            {
                if (input == "end of shift")
                {
                    break;
                }

                Regex match = new Regex(pattern);

                bool isMatchValid = match.IsMatch(input);
                if (isMatchValid)
                {
                    string customer = match.Match(input).Groups["customer"].Value;
                    string product = match.Match(input).Groups["product"].Value;
                    int quantity = int.Parse(match.Match(input).Groups["quantity"].Value);
                    double price = double.Parse(match.Match(input).Groups["price"].Value);

                    double totalPriceForCurrProduct = quantity * price;
                    totalIncome += totalPriceForCurrProduct;

                    Console.WriteLine($"{customer}: {product} - {totalPriceForCurrProduct:f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
