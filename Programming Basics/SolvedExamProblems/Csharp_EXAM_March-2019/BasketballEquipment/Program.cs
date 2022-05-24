using System;

namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int taxYear = int.Parse(Console.ReadLine());

            double sneakers = taxYear * 0.60;
            double suit = sneakers * 0.80;
            double ball = suit * 0.25;
            double accessories = ball * 0.20;

            double equipment = taxYear + sneakers + suit + accessories + ball;
            Console.WriteLine($"{equipment:f2}");
        }
    }
}
