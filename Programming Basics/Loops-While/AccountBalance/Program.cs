using System;

namespace AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0.0;
            while (input != "NoMoreMoney")
            {
                double amount = double.Parse(input);
                if (amount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                    balance += amount;
                    Console.WriteLine($"Increase: {amount:F2}");
                    input = Console.ReadLine();                                
            }
            Console.WriteLine($"Total: {balance:F2}");
        }
    }
}
