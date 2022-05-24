using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceR = double.Parse(Console.ReadLine());
            int quantityR = int.Parse(Console.ReadLine());
            int quantityS = int.Parse(Console.ReadLine());

            double allRprice = priceR * quantityR;
            double priceS = priceR / 6;
            double allSprice = priceS * quantityS;

            double otherEquipmentPrice = (allRprice + allSprice) * 0.20;
            double allEquipment = allRprice + allSprice + otherEquipmentPrice;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(allEquipment / 8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(allEquipment * 7 / 8)}");
        }
    }
}
