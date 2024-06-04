using System;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double allExpense = 0.0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                double pricePerOrder = 0.0;

                double priceCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int countCapsule = int.Parse(Console.ReadLine());

                pricePerOrder = (countCapsule * days) * priceCapsule;
                Console.WriteLine($"The price for the coffee is: ${pricePerOrder:f2}");
                allExpense += pricePerOrder;
            }
            Console.WriteLine($"Total: ${allExpense:f2}");
        }
    }
}
