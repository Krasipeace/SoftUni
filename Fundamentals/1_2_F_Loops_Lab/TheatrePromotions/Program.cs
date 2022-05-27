using System;

namespace TheatrePromotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            if (day == "Weekday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 12;
                }
                else if (age <= 64)
                {
                    price = 18;
                }
                else if (age <= 122)
                {
                    price = 12;
                }

            }
            else if (day == "Weekend")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 15;
                }
                else if (age <= 64)
                {
                    price = 20;
                }
                else if (age <= 122)
                {
                    price = 15;
                }

            }
            else if (day == "Holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 5;
                }
                else if (age <= 64)
                {
                    price = 12;
                }
                else if (age <= 122)
                {
                    price = 10;
                }

            }
            if (age >= 0 && age <= 122)
            {
                Console.WriteLine($"{price}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
