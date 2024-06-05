using System;

namespace BarcodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intervalOne = int.Parse(Console.ReadLine());
            int intervalTwo = int.Parse(Console.ReadLine());

            int iOne = (intervalOne / 1000) % 10;
            int jOne = (intervalOne / 100) % 10;
            int kOne = (intervalOne / 10) % 10;
            int lOne = (intervalOne / 1) % 10;

            int iTwo = (intervalTwo / 1000) % 10;
            int jTwo = (intervalTwo / 100) % 10;
            int kTwo = (intervalTwo / 10) % 10;
            int lTwo = (intervalTwo / 1) % 10;

            for (int i = iOne; i <= iTwo; i++)
            {
                for (int j = jOne; j <= jTwo; j++)
                {
                    for (int k = kOne; k <= kTwo; k++)
                    {
                        for (int l = lOne; l <= lTwo; l++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 && k % 2 != 0 && l % 2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                            if (i == iTwo && j == jTwo && k == kTwo && l == lTwo)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
