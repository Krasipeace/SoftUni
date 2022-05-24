using System;

namespace Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double sumPoints = points;

            for (int i = 1; i <= n; i++)
            {
                string awarderName = Console.ReadLine();
                double awarderPoints = double.Parse(Console.ReadLine());
                int namePoints = awarderName.Length;
                sumPoints += namePoints * awarderPoints / 2;
                if (sumPoints >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {sumPoints:f1}!");
                    break;
                }
            }
            if (sumPoints < 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - sumPoints:f1} more!");
            }
        }
    }
}
