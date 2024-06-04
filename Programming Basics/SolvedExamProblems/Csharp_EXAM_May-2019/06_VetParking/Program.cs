using System;

namespace _06_VetParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double finalPrice = 0;
            double dayPrice = 0;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                for (int currentHour = 1; currentHour <= hours; currentHour++)
                {                    
                    double price = 0;
                    if (currentDay % 2 == 0)
                    {
                        if (currentHour % 2 != 0)
                        {
                            price += 2.50;
                        }
                        else
                        {
                            price += 1.00;
                        }
                    }
                    else if (currentDay % 2 != 0)
                    {
                        if (currentHour % 2 == 0)
                        {
                            price += 1.25;
                        }
                        else
                        {
                            price += 1.00;
                        }
                    }
                    dayPrice += price;
                }
                finalPrice += dayPrice;
                Console.WriteLine($"Day: {currentDay} - {dayPrice:f2} leva");
                dayPrice = 0;
            }
            
            Console.WriteLine($"Total: {finalPrice:f2} leva");
        }
    }
}
