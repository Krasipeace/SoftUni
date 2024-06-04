using System;

namespace GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double spentMoney = money;
            bool outOfMoney = false;

            while (money >= 0)
            {
                string product = Console.ReadLine();
                if (product == "Game Time")
                {
                    outOfMoney = false;
                    break;
                }
                else if (product == "OutFall 4")
                {
                    money -= 39.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 39.99;
                        outOfMoney = true;                        
                    }
                    else
                    {
                        Console.WriteLine("Bought OutFall 4");
                    }
                }
                else if (product == "CS: OG")
                {
                    money -= 15.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 15.99;
                        outOfMoney = true;                       
                    }
                    else
                    {
                        Console.WriteLine("Bought CS: OG");
                    }
                }
                else if (product == "Zplinter Zell")
                {
                    money -= 19.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 19.99;
                        outOfMoney = true;                       
                    }
                    else
                    {
                        Console.WriteLine("Bought Zplinter Zell");
                    }
                }
                else if (product == "Honored 2")
                {
                    money -= 59.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 59.99;
                        outOfMoney = true;                       
                    }
                    else
                    {
                        Console.WriteLine("Bought Honored 2");
                    }
                }
                else if (product == "RoverWatch")
                {
                    money -= 29.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 29.99;
                        outOfMoney = true;                        
                    }
                    else
                    {
                        Console.WriteLine("Bought RoverWatch");
                    }
                }
                else if (product == "RoverWatch Origins Edition")
                {
                    money -= 39.99;                   
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 39.99;
                        outOfMoney = true;                        
                    }
                    else
                    {                        
                        Console.WriteLine("Bought RoverWatch Origins Edition");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
            if (outOfMoney)
            {
                Console.WriteLine("Out of money!");
                return;
            }
            else
            {
                spentMoney -= money;
                Console.WriteLine($"Total spent: ${spentMoney:f2}. Remaining: ${money:f2}");
            }
        }
    }
}
