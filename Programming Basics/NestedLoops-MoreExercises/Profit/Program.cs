using System;

namespace Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counterOne = int.Parse(Console.ReadLine());
            int counterTwo = int.Parse(Console.ReadLine());
            int counterFive = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());
            
            for (int i = 0; i <= counterOne; i++)
            {
                for (int j = 0; j <= counterTwo; j++)
                {
                    for (int k = 0; k <= counterFive; k++)
                    {
                        if ((i * 1) + (j * 2) + (k * 5) == sum)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
