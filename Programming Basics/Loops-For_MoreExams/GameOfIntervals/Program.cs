using System;

namespace GameOfIntervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());
            double points = 0.0;
            double pFirstNumbers = 0.0;
            double pSecondNumbers = 0.0;
            double pThirdNumbers = 0.0;
            double pFiftyNumbers = 0.0;
            double pOnehNumbers = 0.0;
            double pInvalidNumbers = 0.0;

            for (int i = 1; i <= turns; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number >= 0 && number <= 9)
                {
                    points += number * 0.20;
                    pFirstNumbers += 1;
                }
                else if (number >= 10 && number <= 19)
                {
                    points += number * 0.30;
                    pSecondNumbers += 1;
                }
                else if (number >= 20 && number <= 29)
                {
                    points += number * 0.40;
                    pThirdNumbers += 1;
                }
                else if (number >= 30 && number <= 39)
                {
                    points += 50;
                    pFiftyNumbers += 1;
                }
                else if (number >= 40 && number <= 50)
                {
                    points += 100;
                    pOnehNumbers += 1;
                }
                else 
                {
                    points = points / 2.0;
                    pInvalidNumbers += 1;
                }
            }
            pFirstNumbers = pFirstNumbers / turns * 100.0;
            pSecondNumbers = pSecondNumbers / turns * 100.0;
            pThirdNumbers = pThirdNumbers / turns * 100.0;
            pFiftyNumbers = pFiftyNumbers / turns * 100.0;
            pOnehNumbers = pOnehNumbers / turns * 100.0;
            pInvalidNumbers = pInvalidNumbers / turns * 100.0;
            Console.WriteLine($"{points:f2}");
            Console.WriteLine($"From 0 to 9: {pFirstNumbers:f2}%");
            Console.WriteLine($"From 10 to 19: {pSecondNumbers:f2}%");
            Console.WriteLine($"From 20 to 29: {pThirdNumbers:f2}%");
            Console.WriteLine($"From 30 to 39: {pFiftyNumbers:f2}%");
            Console.WriteLine($"From 40 to 50: {pOnehNumbers:f2}%");
            Console.WriteLine($"Invalid numbers: {pInvalidNumbers:f2}%");
        }
    }
}
