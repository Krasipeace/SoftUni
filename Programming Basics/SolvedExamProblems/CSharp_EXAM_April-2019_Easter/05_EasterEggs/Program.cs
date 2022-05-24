using System;

namespace _05_EasterEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggsQ = int.Parse(Console.ReadLine());

            int counterR = 0;
            int counterO = 0;
            int counterB = 0;
            int counterG = 0;
            int maxColor = 0;
            string colorMax = string.Empty;

            for (int current = 1; current <= eggsQ; current++)
            {
                string eggColor = Console.ReadLine(); //"red", "orange", "blue", "green"
                if (eggColor == "red")
                {
                    counterR++;
                }
                else if (eggColor == "orange")
                {
                    counterO++;
                }
                else if (eggColor == "blue")
                {
                    counterB++;
                }
                else if (eggColor == "green")
                {
                    counterG++;
                }

            }
            if (counterR > counterO && counterR > counterB && counterR > counterG)
            {
                maxColor = counterR;
                colorMax = "red";
            }
            if (counterO > counterR && counterO > counterB && counterO > counterG)
            {
                maxColor = counterO;
                colorMax = "orange";
            }
            if (counterB > counterO && counterB > counterR && counterB > counterG)
            {
                maxColor = counterB;
                colorMax = "blue";
            }
            if (counterG > counterO && counterG > counterR && counterG > counterB)
            {
                maxColor = counterG;
                colorMax = "green";
            }

            Console.WriteLine($"Red eggs: {counterR}");
            Console.WriteLine($"Orange eggs: {counterO}");
            Console.WriteLine($"Blue eggs: {counterB}");
            Console.WriteLine($"Green eggs: {counterG}");
            Console.WriteLine($"Max eggs: {maxColor} -> {colorMax}");

        }
    }
}
