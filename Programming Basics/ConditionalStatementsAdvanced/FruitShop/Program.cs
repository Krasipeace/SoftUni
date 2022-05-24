using System;

namespace FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double cost;
            if (fruit == "banana")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        cost = quantity * 2.50;
                        Console.WriteLine($"{cost:f2}");
                        break;   
                    case "Saturday":
                    case "Sunday":
                        cost = quantity * 2.70;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    default: Console.WriteLine("error");
                        break;
                }
            }
            else if (fruit == "apple")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        cost = quantity * 1.20;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    case "Saturday":
                    case "Sunday":
                        cost = quantity * 1.25;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (fruit == "orange")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        cost = quantity * 0.85;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    case "Saturday":
                    case "Sunday":
                        cost = quantity * 0.90;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (fruit == "grapefruit")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        cost = quantity * 1.45;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    case "Saturday":
                    case "Sunday":
                        cost = quantity * 1.60;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (fruit == "kiwi")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        cost = quantity * 2.70;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    case "Saturday":
                    case "Sunday":
                        cost = quantity * 3.00;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (fruit == "pineapple")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        cost = quantity * 5.50;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    case "Saturday":
                    case "Sunday":
                        cost = quantity * 5.60;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (fruit == "grapes")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        cost = quantity * 3.85;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    case "Saturday":
                    case "Sunday":
                        cost = quantity * 4.20;
                        Console.WriteLine($"{cost:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
