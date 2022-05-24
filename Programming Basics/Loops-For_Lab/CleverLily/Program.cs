using System;

namespace CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashMac = double.Parse(Console.ReadLine());
            int priceToy = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i * 5 - 1;                  
                }
                else 
                {
                    sum += priceToy;
                }
            }
            if (sum >= priceWashMac)
            {
                Console.WriteLine($"Yes! {sum - priceWashMac:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceWashMac - sum:f2}");
            }
        }
    }
}
