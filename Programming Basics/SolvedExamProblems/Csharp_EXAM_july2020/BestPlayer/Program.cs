using System;

namespace BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int goals = int.Parse(Console.ReadLine());
            int maxGoals = 0;
            string hatTricker = string.Empty;

            while (input != "END")
            {
                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    hatTricker = input;
                    if (maxGoals >= 10)
                    {
                        break;
                    }
                }
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }                
                goals = int.Parse(Console.ReadLine());
            }
            if (maxGoals >= 3)
            {
                Console.WriteLine($"{hatTricker} is the best player!");
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"{hatTricker} is the best player!");
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
