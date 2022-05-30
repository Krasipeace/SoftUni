using System;

namespace zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int type = 2; type <= 14; type++)
            {
                string paint = string.Empty;
                string tenPlus = string.Empty;
                switch (type)
                {
                    case 11: tenPlus = "J";
                        break;
                    case 12: tenPlus = "Q";
                        break;
                    case 13: tenPlus = "K";
                        break;
                    case 14: tenPlus = "A";
                        break;
                }
                for (int p = 1; p <= 4; p++)
                {
                    
                    switch (p)
                    {
                        case 1: paint = "Spades";
                            break;
                        case 2: paint = "Clubs";
                            break;
                        case 3: paint = "Hearts";
                            break;
                        case 4: paint = "Diamonds";
                            break;
                    }
                    if (type <= 10)
                    {
                        Console.WriteLine($"{type} {paint}");
                    }
                    else
                    {
                        Console.WriteLine($"{tenPlus} {paint}");
                    }
                }

            }
        }
    }
}
