using System;

namespace _05_EasterBake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int easterBreads = int.Parse(Console.ReadLine());

            double packSugar = 0;
            double packFlour = 0;
            double sugarNeed = 0;
            double flourNeed = 0;
            int sugarMax = int.MinValue;
            int flourMax = int.MinValue;

            for (int i = 1; i <= easterBreads; i++)
            {
                int sugarQ = int.Parse(Console.ReadLine());
                int flourQ = int.Parse(Console.ReadLine());

                sugarNeed += sugarQ;
                flourNeed += flourQ;
                if (sugarQ >= sugarMax)
                {
                    sugarMax = sugarQ;
                }
                if (flourQ >= flourMax)
                {
                    flourMax = flourQ;
                }

            }

            packSugar = Math.Ceiling(sugarNeed / 950);
            packFlour = Math.Ceiling(flourNeed / 750);

            Console.WriteLine($"Sugar: {packSugar}");
            Console.WriteLine($"Flour: {packFlour}");
            Console.WriteLine($"Max used flour is {flourMax} grams, max used sugar is {sugarMax} grams.");
        }
    }
}
