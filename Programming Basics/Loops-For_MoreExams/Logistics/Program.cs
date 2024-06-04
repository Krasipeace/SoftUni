using System;

namespace Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCarriage = int.Parse(Console.ReadLine());
            double pMinibus = 0.0;
            double pTruck = 0.0;
            double pTrain = 0.0;
            int sumOfCarriage = 0;
            double tMiniBus = 0.0;
            double tTruck = 0.0;
            double tTrain = 0.0;

            for (int i = 1; i <= numOfCarriage; i++)
            {
                int weightOfCarriage = int.Parse(Console.ReadLine());
                sumOfCarriage += weightOfCarriage;
                if (weightOfCarriage <= 3)
                {
                    tMiniBus += weightOfCarriage;
                }
                else if (weightOfCarriage <= 11)
                {
                    tTruck += weightOfCarriage;
                }
                else
                {
                    tTrain += weightOfCarriage;
                }
            }
            double tonsOfCarriage = (tMiniBus * 200 + tTruck * 175 + tTrain * 120)/sumOfCarriage;
            pMinibus = tMiniBus / sumOfCarriage * 100.0;
            pTruck = tTruck / sumOfCarriage * 100.0;
            pTrain = tTrain / sumOfCarriage * 100.0;
            Console.WriteLine($"{tonsOfCarriage:f2}");
            Console.WriteLine($"{pMinibus:f2}%");
            Console.WriteLine($"{pTruck:f2}%");
            Console.WriteLine($"{pTrain:f2}%");
        }
    }
}
