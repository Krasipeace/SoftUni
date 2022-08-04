using System;

namespace _1._Sino_The_Walker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputTime = Console.ReadLine();
            int steps = int.Parse(Console.ReadLine());
            double secPerStep = double.Parse(Console.ReadLine());

            double timeAllSteps = steps * secPerStep;

            DateTime time = DateTime.Parse(inputTime);
            DateTime endTime = time.AddSeconds(timeAllSteps);

            Console.WriteLine("Time Arrival: {0}", endTime.ToString("HH:mm:ss"));

        }
    }
}
