using System;

namespace BackToThePast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double heritage = double.Parse(Console.ReadLine());
            int yearOfDeath = int.Parse(Console.ReadLine());
            int ageIvan = 17;
            
            for (int i = 1800; i <= yearOfDeath; i++)
            {
                ageIvan += 1;
                if (ageIvan % 2 == 0)
                {
                    heritage = heritage - 12000;
                }
                else
                {
                    heritage = heritage - 12000 - (50 * ageIvan);
                }
            }
            if (heritage >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {heritage:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(heritage):f2} dollars to survive.");
            }
        }
    }
}
