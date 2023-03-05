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

            days--;
            double priceAp = 25.0 * days;
            double pricePres = 35.0 * days;
            double priceRoom = 18.00 * days;

            switch (days)
            {
                case < 10:
                    if (place == "apartment")
                    {
                        priceAp -= priceAp * 0.30;

                        switch (assessment)
                        {
                            case "positive":
                                priceAp += priceAp * 0.25;
                                Console.WriteLine($"{priceAp:f2}");
                                break;
                            case "negative":
                                priceAp -= priceAp * 0.10;
                                Console.WriteLine($"{priceAp:f2}");
                                break;
                        }
                    }
                    else if (place == "president apartment")
                    {
                        pricePres -= pricePres * 0.10;

                        switch (assessment)
                        {
                            case "positive":
                                pricePres += pricePres * 0.25;
                                Console.WriteLine($"{pricePres:f2}");
                                break;
                            case "negative":
                                pricePres -= pricePres * 0.10;
                                Console.WriteLine($"{pricePres:f2}");
                                break;
                        }

                    }
                    break;
                case >= 10 and <= 15:
                    if (place == "apartment")
                    {
                        priceAp -= priceAp * 0.35;

                        switch (assessment)
                        {
                            case "positive":
                                priceAp += priceAp * 0.25;
                                Console.WriteLine($"{priceAp:f2}");
                                break;
                            case "negative":
                                priceAp -= priceAp * 0.10;
                                Console.WriteLine($"{priceAp:f2}");
                                break;
                        }
                    }
                    else if (place == "president apartment")
                    {
                        pricePres -= pricePres * 0.15;

                        switch (assessment)
                        {
                            case "positive":
                                pricePres += pricePres * 0.25;
                                Console.WriteLine($"{pricePres:f2}");
                                break;
                            case "negative":
                                pricePres -= pricePres * 0.10;
                                Console.WriteLine($"{pricePres:f2}");
                                break;
                        }
                    }
                    break;
                case > 15:
                    if (place == "apartment")
                    {
                        priceAp -= priceAp * 0.50;

                        switch (assessment)
                        {
                            case "positive":
                                priceAp += priceAp * 0.25;
                                Console.WriteLine($"{priceAp:f2}");
                                break;
                            case "negative":
                                priceAp -= priceAp * 0.10;
                                Console.WriteLine($"{priceAp:f2}");
                                break;
                        }
                    }
                    else if (place == "president apartment")
                    {
                        pricePres -= pricePres * 0.20;

                        switch (assessment)
                        {
                            case "positive":
                                pricePres += pricePres * 0.25;
                                Console.WriteLine($"{pricePres:f2}");
                                break;
                            case "negative":
                                pricePres -= pricePres * 0.10;
                                Console.WriteLine($"{pricePres:f2}");
                                break;
                        }
                    }
                    break;
            }

            switch (assessment)
            {
                case "positive":
                    if (place == "room for one person")
                    {
                        priceRoom += priceRoom * 0.25;
                        Console.WriteLine($"{priceRoom:f2}");
                    }
                    break;
                case "negative":
                    if (place == "room for one person")
                    {
                        priceRoom -= priceRoom * 0.10;
                        Console.WriteLine($"{priceRoom:f2}");
                    }
                    break;
            }
        }
    }
}
