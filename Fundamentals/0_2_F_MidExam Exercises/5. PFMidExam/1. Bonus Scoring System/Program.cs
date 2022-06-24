using System;

namespace _1._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            double bonusPoints = double.Parse(Console.ReadLine());
            double bestStudent = 0.0;
            double totalBonus = 0.0;

            for (int i = 1; i <= numberOfStudents; i++)
            {
                double studentScore = double.Parse(Console.ReadLine());
                if (studentScore > bestStudent)
                {
                    bestStudent = studentScore;
                }
                totalBonus = Math.Ceiling((bestStudent / numberOfLectures) * (5 + bonusPoints));
            }                      

            Console.WriteLine($"Max Bonus: {totalBonus:f0}.");
            Console.WriteLine($"The student has attended {bestStudent} lectures.");            
        }
    }
}
