using System;

namespace _05_Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double pointsAcademy = double.Parse(Console.ReadLine());
            int jury = int.Parse(Console.ReadLine());
            double pointsSum = pointsAcademy;

            for (int currentJury = 1; currentJury <= jury; currentJury++)
            {
                string juryName = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                int juryNpoints = juryName.Length;
                double juryAllPoints = (juryNpoints * juryPoints) / 2;
                pointsSum += juryAllPoints;
                
                if (pointsSum >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {pointsSum:f1}!");
                    break;
                }
                
            }
            if (pointsSum < 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {Math.Abs(1250.5 - pointsSum):f1} more!");
            }
            
        }
    }
}
