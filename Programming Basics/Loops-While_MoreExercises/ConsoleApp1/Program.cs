using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double needMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());
            int dayCounter = 0;
            int spendCounter = 0;
            string input = "";
            double money = 0.0;
            while (ownedMoney < needMoney && spendCounter < 5)
            {
                input = Console.ReadLine();
                money = double.Parse(Console.ReadLine());
                dayCounter++;
                if (input == "save")
                {
                    ownedMoney += money;
                    spendCounter = 0;
                }
                else
                {
                    ownedMoney -= money;
                    if (ownedMoney < 0)
                    {
                        ownedMoney = 0;
                    }
                    spendCounter++;
                    if (spendCounter == 5)
                    {
                        Console.WriteLine($"You can't save the money.");
                        Console.WriteLine(dayCounter);
                        break;
                    }
                }
            }
            if (ownedMoney >= needMoney)
            {
                Console.WriteLine($"You saved the money for {dayCounter} days.");
            }
        }
    }
}