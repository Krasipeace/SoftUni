using System;

namespace _1._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double pricesNoTax = 0;
            double allTaxes = 0;
            double priceFinal = 0;

            while (true)
            {
                if (input == "regular" || input == "special")
                {
                    break;
                }
                double inputPrice = double.Parse(input);

                if (inputPrice <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    pricesNoTax += inputPrice;                    
                    allTaxes += inputPrice * 0.2;
                    priceFinal += inputPrice * 1.2;
                }

                input = Console.ReadLine();
            }

            priceFinal = GetFinalPrice(input, pricesNoTax, allTaxes, priceFinal);
        }

        static double GetFinalPrice(string input, double pricesNoTax, double allTaxes, double priceFinal)
        {
            if (priceFinal == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else if (input == "special")
            {
                priceFinal *= 0.9;
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {pricesNoTax:f2}$");
                Console.WriteLine($"Taxes: {allTaxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {priceFinal:f2}$");
            }
            else if (input == "regular")
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {pricesNoTax:f2}$");
                Console.WriteLine($"Taxes: {allTaxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {priceFinal:f2}$");
            }

            return priceFinal;
        }
    }
}
