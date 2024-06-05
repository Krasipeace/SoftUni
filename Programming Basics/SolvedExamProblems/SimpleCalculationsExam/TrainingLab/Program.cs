using System;

namespace TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double rows = length * 100 / 120;
            double columns = ((width * 100) - 100) / 70;
            double row = Math.Truncate(rows); 
            double col = Math.Truncate(columns); 
            Console.WriteLine((row * col) - 3);
        }
    }
}
