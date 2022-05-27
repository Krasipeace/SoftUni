using System;

namespace PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceSabres = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double sabres = students + (students * 0.10);
            int sabresQ = (int)Math.Ceiling(sabres);
            double costSabres = sabresQ * priceSabres;

            double costRobes = priceRobes * students;

            int freeBelts = 0;
            for (int i = 1; i <= students; i++)
            {
                if (i % 6 == 0)
                {
                    freeBelts++;
                }
            }
            int allBelts = students - freeBelts;
            double costBelts = priceBelts * allBelts;

            double allCost = costSabres + costRobes + costBelts;
            if (allCost <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {allCost:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {Math.Abs(allCost - money):f2}lv more.");
            }


        }
    }
}
