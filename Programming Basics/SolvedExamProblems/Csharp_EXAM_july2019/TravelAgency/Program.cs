using System;

namespace TravelAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();  //    "Bansko",  "Borovets",              "Varna" или "Burgas"
            string pack = Console.ReadLine();  // "noEquipment",  "withEquipment"   "noBreakfast" или "withBreakfast"
            string vip = Console.ReadLine();   // yes  no  
            int days = int.Parse(Console.ReadLine());
            double price = 0;

            if (days > 7)
            {
                days = days - 1;
            }
            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }
            if (city == "Bansko" || city == "Borovets")
            {
                if (pack == "noEquipment")
                {
                    price = 80.0;
                    if (vip == "yes")
                    {
                        price = price - price * 0.05;
                    }
                }
                else if (pack == "withEquipment")
                {
                    price = 100.0;
                    if (vip == "yes")
                    {
                        price = price - price * 0.10;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return;
                }
            }
            else if (city == "Varna" || city == "Burgas")
            {
                if (pack == "noBreakfast")
                {
                    price = 100.0;
                    if (vip == "yes")
                    {
                        price = price - price * 0.07;
                    }
                }
                else if (pack == "withBreakfast")
                {
                    price = 130.0;
                    if (vip == "yes")
                    {
                        price = price - price * 0.12;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }   
            
            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            {
                double finalPrice = days * price;
                Console.WriteLine($"The price is {finalPrice:f2}lv! Have a nice time!");
            }
        }
    }
}
