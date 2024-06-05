using System;

namespace EnergyBooster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //                     Диня               Манго               Ананас                 Малина
            //
            //2 броя (small)    56 лв./ бр.         36.66 лв./бр.       42.10 лв./ бр.          20 лв./ бр.
            //5 броя (big)      28.70 лв./бр.       19.60 лв./бр.       24.80 лв./бр.           15.20 лв./бр.
            // |  от 400 лв.до 1000 лв.включително има 15 % отстъпка          || над 1000 лв.има 50 % отстъпка

            string fruit = Console.ReadLine(); // 1. "Watermelon", "Mango", "Pineapple" или "Raspberry"
            string set = Console.ReadLine();   //small | big
            int setNum = int.Parse(Console.ReadLine());
            double money = 0;

            if (fruit == "Watermelon")
            {
                if (set == "small")
                {
                    money = 56.00 * 2 * setNum;
                }
                else if (set == "big")
                {
                    money = 28.70 * 5 * setNum;
                }
            }
            else if (fruit == "Mango")
            {
                if (set == "small")
                {
                    money = 36.66 * 2 * setNum;
                }
                else if (set == "big")
                {
                    money = 19.60 * 5 * setNum;
                }
            }
            else if (fruit == "Pineapple")
            {
                if (set == "small")
                {
                    money = 42.10 * 2 * setNum;
                }
                else if (set == "big")
                {
                    money = 24.80 * 5 * setNum;
                }
            }
            else if (fruit == "Raspberry")
            {
                if (set == "small")
                {
                    money = 20.00 * 2 * setNum;
                }
                else if (set == "big")
                {
                    money = 15.20 * 5 * setNum;
                }
            }
            if (money >= 400 && money <= 1000)
            {
                money = money - (money * 0.15);
            }
            else if (money > 1000)
            {
                money = money - (money * 0.50);
            }
            Console.WriteLine($"{money:f2} lv.");
        }
    }
}
