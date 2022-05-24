using System;

namespace SuitcasesLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double trunk = double.Parse(Console.ReadLine());
            string input = string.Empty;
            int suitcase = 0;
            double capacity;

            while (trunk > 0)
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine($"Congratulations! All suitcases are loaded!");
                    break;
                }
                suitcase++;
                capacity = double.Parse(input);
                if (suitcase % 3 == 0)
                {
                    capacity += capacity * 0.1;
                }
                if (capacity >= trunk)
                {
                    Console.WriteLine("No more space!");
                    suitcase--;
                    break;
                }
                trunk -= capacity;
            }
            Console.WriteLine($"Statistic: {suitcase} suitcases loaded.");
        }
    }
}
