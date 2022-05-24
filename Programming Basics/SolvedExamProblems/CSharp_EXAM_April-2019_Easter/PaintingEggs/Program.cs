using System;

namespace PaintingEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eggSize = Console.ReadLine(); // "Large", "Medium" или "Small"
            string eggColor = Console.ReadLine(); // "Red", "Green" или "Yellow"
            int eggsQ = int.Parse(Console.ReadLine());
            double price = 0;

            if (eggSize == "Large")
            {
                if (eggColor == "Red")
                {
                    price = eggsQ * 16;
                }
                else if (eggColor == "Green")
                {
                    price = eggsQ * 12;
                }
                else if (eggColor == "Yellow")
                {
                    price = eggsQ * 9;
                }

            }
            else if (eggSize == "Medium")
            {
                if (eggColor == "Red")
                {
                    price = eggsQ * 13;
                }
                else if (eggColor == "Green")
                {
                    price = eggsQ * 9;
                }
                else if (eggColor == "Yellow")
                {
                    price = eggsQ * 7;
                }

            }
            else if (eggSize == "Small")
            {
                if (eggColor == "Red")
                {
                    price = eggsQ * 9;
                }
                else if (eggColor == "Green")
                {
                    price = eggsQ * 8;
                }
                else if (eggColor == "Yellow")
                {
                    price = eggsQ * 5;
                }

            }

            double production = price * 0.35;
            double finalCost = price - production;
            Console.WriteLine($"{finalCost:f2} leva.");

        }
    }
}
