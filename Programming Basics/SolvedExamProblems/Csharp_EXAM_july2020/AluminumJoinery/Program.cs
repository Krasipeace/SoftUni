using System;

namespace AluminumJoinery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   Размер   Единична цена    Отстъпка от цената
            //
            //   90X130       110 лв.      Над 30 броя – 5 %
            //                             Над 60 броя – 8 %
            //  
            //   100X150     140 лв.       Над 40 броя – 6 %
            //                             Над 80 броя – 10 %
            //
            //   130X180     190 лв.       Над 20 броя – 7 %
            //                             Над 50 броя – 12 %
            //
            //   200X300      250 лв.      Над 25 броя – 9 %
            //                             Над 50 броя – 14 %
            
            int numOrders = int.Parse(Console.ReadLine());
            string typeOfOrder = Console.ReadLine();
            string delivery = Console.ReadLine();
            double finalPrice = 0.0;

            if (typeOfOrder == "90X130")
            {
                finalPrice = numOrders * 110.0;
                if (numOrders >= 60)
                {                    
                    finalPrice = finalPrice - finalPrice * 0.08;
                }
                else if (numOrders >= 30)
                {
                    finalPrice = finalPrice - finalPrice * 0.05;
                }                
            }
            else if (typeOfOrder == "100X150")
            {
                finalPrice = numOrders * 140.0;
                if (numOrders >= 80)
                {
                    finalPrice = finalPrice - finalPrice * 0.10;
                }
                else if (numOrders >= 40)
                {
                    finalPrice = finalPrice - finalPrice * 0.06;
                }                
            }
            else if (typeOfOrder == "130X180")
            {
                finalPrice = numOrders * 190.0;
                if (numOrders >= 50)
                {
                    finalPrice = finalPrice - finalPrice * 0.12;
                }
                else if (numOrders >= 20)
                {
                    finalPrice = finalPrice - finalPrice * 0.07;
                }                
            }
            else if (typeOfOrder == "200X300")
            {
                finalPrice = numOrders * 250.0;
                if (numOrders >= 50)
                {
                    finalPrice = finalPrice - finalPrice * 0.14;
                }
                else if (numOrders >= 25)
                {
                    finalPrice = finalPrice - finalPrice * 0.09;
                }                
            }
            if (delivery == "With delivery")
            {
                finalPrice = finalPrice + 60.0;
            }

            if (numOrders < 10)
            {
                Console.WriteLine("Invalid order");
            }
            else if (numOrders > 99)
            {
                finalPrice = finalPrice - finalPrice * 0.04;
                Console.WriteLine($"{finalPrice:f2} BGN");
            }
            else
            {
                Console.WriteLine($"{finalPrice:f2} BGN");
            }

        }
    }
}
