using System;

namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpuQ = int.Parse(Console.ReadLine());
            int cpuQ = int.Parse(Console.ReadLine());
            int ramQ = int.Parse(Console.ReadLine());
 
            double gpuPrice = gpuQ * 250;
            double cpuPrice = cpuQ * gpuPrice * 0.35;
            double ramPrice = ramQ * gpuPrice * 0.10;

            double totalPrice = gpuPrice + cpuPrice + ramPrice;

            if (gpuQ > cpuQ)
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            if (totalPrice <= budget)
            {
                Console.WriteLine($"You have {budget - totalPrice:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:F2} leva more!");
            }
        }
    }
}
