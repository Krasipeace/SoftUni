using System;

namespace _05_Series
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int series = int.Parse(Console.ReadLine());
            double allPrice = 0;

            for (int i = 1; i <= series; i++)
            {
                string tvName = Console.ReadLine();
                double tvPrice = double.Parse(Console.ReadLine());
                

                if (tvName == "Thrones")
                {
                    allPrice += tvPrice * 0.50;
                }
                else if (tvName == "Lucifer")
                {
                    allPrice += tvPrice * 0.60;
                }
                else if (tvName == "Protector")
                {
                    allPrice += tvPrice * 0.70;
                }
                else if (tvName == "TotalDrama")
                {
                    allPrice += tvPrice * 0.80;
                }
                else if (tvName == "Area")
                {
                    allPrice += tvPrice * 0.90;
                }
                else
                {
                    allPrice += tvPrice;
                }

            }

            if (allPrice <= budget)
            {
                Console.WriteLine($"You bought all the series and left with {budget - allPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {Math.Abs(allPrice - budget):f2} lv. more to buy the series!");
            }
        }     
    }
}
