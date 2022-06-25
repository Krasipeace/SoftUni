using System;

namespace _1._Black_Flag  //Pirates are invading the sea, and you're tasked to help them plunder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double sumPlunder = 0;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                sumPlunder += dailyPlunder;
                if (currentDay % 3 == 0)
                {
                    sumPlunder += 0.5 * dailyPlunder;
                }
                if (currentDay % 5 == 0)
                {
                    sumPlunder *= 0.70;
                }
            }
            if (sumPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {sumPlunder:f2} plunder gained.");
            }
            else
            {
                double collectedPlunder = sumPlunder / expectedPlunder * 100.0;
                Console.WriteLine($"Collected only {collectedPlunder:f2}% of the plunder.");
            }
        }
    }
}



