using System;

namespace ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceTrip = double.Parse(Console.ReadLine());
            int puzzleQ = int.Parse(Console.ReadLine());
            int dollsQ = int.Parse(Console.ReadLine());
            int bearsQ = int.Parse(Console.ReadLine());
            int minionsQ = int.Parse(Console.ReadLine());
            int trucksQ = int.Parse(Console.ReadLine());

            int toysQ = puzzleQ + dollsQ + bearsQ + minionsQ + trucksQ;

            double totalPrice = puzzleQ * 2.6 + dollsQ * 3 + bearsQ*4.1 + minionsQ*8.2 + trucksQ*2;

            if (toysQ >= 50)
            {
                totalPrice = totalPrice - totalPrice * 0.25; //отстъпка
            }

            totalPrice = totalPrice - totalPrice * 0.10; //изваждаме наема

            double difference = totalPrice - priceTrip; //разликата между цена на наема и цена на екс.
            if (difference >= 0)
                {
                    Console.WriteLine($"Yes! {difference:F2} lv left.");
                }
            else
                {
                    Console.WriteLine($"Not enough money! {Math.Abs(difference):F2} lv needed.");
                }


        }
    }
}
