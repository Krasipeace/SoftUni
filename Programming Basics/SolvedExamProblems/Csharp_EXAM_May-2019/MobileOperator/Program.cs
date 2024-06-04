using System;

namespace MobileOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string contractTime = Console.ReadLine();
            string contractType = Console.ReadLine();
            string internet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double price = 0;

            if (contractTime == "one")
            {
                if (contractType == "Small")
                {
                    if (internet == "yes")
                    {
                        price = (5.50 + 9.98) * months;
                    }
                    else if (internet == "no")
                    {
                        price = months * 9.98;
                    }                   
                }
                else if (contractType == "Middle")
                {
                    if (internet == "yes")
                    {
                        price = (4.35 + 18.99) * months;
                    }
                    else if (internet == "no")
                    {
                        price = months * 18.99;
                    }
                }
                else if (contractType == "Large")
                {
                    if (internet == "yes")
                    {
                        price = (4.35 + 25.98) * months;
                    }
                    else if (internet == "no")
                    {
                        price = months * 25.98;
                    }
                }
                else if (contractType == "ExtraLarge")
                {
                    if (internet == "yes")
                    {
                        price = (3.85 + 35.99) * months;
                    }
                    else if (internet == "no")
                    {
                        price = months * 35.99;
                    }
                }
            }
            else if (contractTime == "two")
            {
                if (contractType == "Small")
                {
                    if (internet == "yes")
                    {
                        price = (5.50 + 8.58) * months;
                    }
                    else if (internet == "no")
                    {
                        price = months * 8.58;
                    }
                }
                else if (contractType == "Middle")
                {
                    if (internet == "yes")
                    {
                        price = (4.35 + 17.09) * months;
                    }
                    else if (internet == "no")
                    {
                        price = months * 17.09;
                    }
                }
                else if (contractType == "Large")
                {
                    if (internet == "yes")
                    {
                        price = (4.35 + 23.59) * months;
                    }
                    else if (internet == "no")
                    {
                        price = months * 23.59;
                    }
                }
                else if (contractType == "ExtraLarge")
                {
                    if (internet == "yes")
                    {
                        price = (3.85 + 31.79) * months;
                    }
                    else if (internet == "no")
                    {
                        price = months * 31.79;
                    }
                }
                price -= (price * 3.75 / 100);
            }

            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
