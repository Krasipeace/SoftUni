using System;

namespace SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int spiceYield = int.Parse(Console.ReadLine());
            int days = 0;
            int spiceExtracted = 0;

            while (spiceYield >= 100)
            {
                spiceExtracted += spiceYield - 26;
                spiceYield -= 10;
                days++;
            }
            if (spiceExtracted >= 26)
            {
                spiceExtracted -= 26;
                Console.WriteLine(days);
                Console.WriteLine(spiceExtracted);
            }
            else
            {
                Console.WriteLine(days);
                Console.WriteLine(spiceExtracted);
            }
        }
    }
}
