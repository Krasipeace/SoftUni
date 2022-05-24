using System;

namespace SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string place = Console.ReadLine();
            string assessment = Console.ReadLine();
            days = days - 1;
            double priceAp = 25.0 * days;
            double pricePres = 35.0 * days;
            double priceRoom = 18.00 * days;
            if (days < 10)
            {
                if (place == "apartment")
                {
                    priceAp = priceAp - priceAp * 0.30;
                    if (assessment == "positive")
                    {
                        priceAp = priceAp + priceAp * 0.25;
                        Console.WriteLine($"{priceAp:f2}");
                    }
                    else if (assessment == "negative")
                    {
                        priceAp = priceAp - priceAp * 0.10;
                        Console.WriteLine($"{priceAp:f2}");
                    }
                }
                else if (place == "president apartment")
                {
                    pricePres = pricePres - pricePres * 0.10;
                    if (assessment == "positive")
                    {
                        if (assessment == "positive")
                        {
                            pricePres = pricePres + pricePres * 0.25;
                            Console.WriteLine($"{pricePres:f2}");
                        }
                        else if (assessment == "negative")
                        {
                            pricePres = pricePres - pricePres * 0.10;
                            Console.WriteLine($"{pricePres:f2}");
                        }
                    }
                }
            }
            else if (days >= 10 && days <= 15)
            {
                if (place == "apartment")
                {
                    priceAp = priceAp - priceAp * 0.35;
                    if (assessment == "positive")
                    {
                        priceAp = priceAp + priceAp * 0.25;
                        Console.WriteLine($"{priceAp:f2}");
                    }
                    else if (assessment == "negative")
                    {
                        priceAp = priceAp - priceAp * 0.10;
                        Console.WriteLine($"{priceAp:f2}");
                    }
                }
                else if (place == "president apartment")
                {
                    pricePres = pricePres - pricePres * 0.15;
                    if (assessment == "positive")
                    {
                        pricePres = pricePres + pricePres * 0.25;
                        Console.WriteLine($"{pricePres:f2}");
                    }
                    else if (assessment == "negative")
                    {
                        pricePres = pricePres - pricePres * 0.10;
                        Console.WriteLine($"{pricePres:f2}");
                    }
                }
            }
            else if (days > 15)
            {                
                if (place == "apartment")
                {
                    priceAp = priceAp - priceAp * 0.50;
                    if (assessment == "positive")
                    {
                        priceAp = priceAp + priceAp * 0.25;
                        Console.WriteLine($"{priceAp:f2}");
                    }
                    else if (assessment == "negative")
                    {
                        priceAp = priceAp - priceAp * 0.10;
                        Console.WriteLine($"{priceAp:f2}");
                    }
                }
                else if (place == "president apartment")
                {
                    pricePres = pricePres - pricePres * 0.20;
                    if (assessment == "positive")
                    {
                        pricePres = pricePres + pricePres * 0.25;
                        Console.WriteLine($"{pricePres:f2}");
                    }
                    else if (assessment == "negative")
                    {
                        pricePres = pricePres - pricePres * 0.10;
                        Console.WriteLine($"{pricePres:f2}");
                    }
                }                
            }      
            if (assessment == "positive")
            {
                if (place == "room for one person")
                {
                    priceRoom = priceRoom + priceRoom * 0.25;
                    Console.WriteLine($"{priceRoom:f2}");
                }
            }
            else if (assessment == "negative")
            {
                if (place == "room for one person")
                {
                    priceRoom = priceRoom - priceRoom * 0.10;
                    Console.WriteLine($"{priceRoom:f2}");
                }
            }
        }
    }
}
