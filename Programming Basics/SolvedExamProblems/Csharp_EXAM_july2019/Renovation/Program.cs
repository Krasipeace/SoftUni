using System;

namespace Renovation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int nonPaint = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int peshoLitres = 0;

            int paintWalls = 4 * height * width;
            double litres = Math.Ceiling(paintWalls - (paintWalls * nonPaint / 100.0));

            while (input != "Tired!")
            {
                peshoLitres = int.Parse(input);
                         
                litres -= peshoLitres;

                if (litres <= 0)
                {
                    break;                                       
                }
                input = Console.ReadLine();
            }
            if (litres == 0)
            {
                Console.WriteLine($"All walls are painted! Great job, Pesho!");                
            }           
            else if (input == "Tired!")
            {
                Console.WriteLine($"{litres} quadratic m left.");                
            }
            else
            {
                Console.WriteLine($"All walls are painted and you have {Math.Abs(litres)} l paint left!");
            }
        }
    }
}
