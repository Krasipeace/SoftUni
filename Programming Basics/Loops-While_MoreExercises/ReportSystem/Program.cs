using System;

namespace ReportSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int money = int.Parse(Console.ReadLine());
            int charity = money;
            string input = Console.ReadLine();
            int counter = 0;
            int counterCc = 0;
            int counterCs = 0;
            double cc = 0;
            double cs = 0;
            double allMoney;

            while (true)
            {
                if (input == "End")
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    break;
                }
                
                money = int.Parse(input);
                counter++;
                if (counter % 2 == 0) // creditcard
                {
                    if (money < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        counterCc++;
                        cc += money;
                        Console.WriteLine("Product sold!");
                    }
                }
                else
                {                    
                    if (money > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        counterCs++;
                        cs += money;
                        Console.WriteLine("Product sold!");
                    }
                }
                allMoney = cc + cs;
                if (allMoney >= charity)
                {
                    double averageCs = cs / counterCs;
                    double averageCc = cc / counterCc;
                    Console.WriteLine($"Average CS: {averageCs:f2}");
                    Console.WriteLine($"Average CC: {averageCc:f2}");
                    return;
                }
                input = Console.ReadLine();
            }
        }
    }
}
