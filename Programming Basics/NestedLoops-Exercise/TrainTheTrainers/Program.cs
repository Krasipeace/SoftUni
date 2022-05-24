using System;

namespace TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string project = Console.ReadLine();
            double gradeAverage = 0;
            int counter = 0;

            while (project != "Finish")
            {
                double grade = 0;
                counter++;
                for (int i = 1; i <= n; i++)
                {
                    grade += double.Parse(Console.ReadLine());
                }
                grade = grade / n;
                gradeAverage += grade;
                Console.WriteLine($"{project} - {grade:f2}.");
                project = Console.ReadLine();
            }
            gradeAverage = gradeAverage / counter;
            Console.WriteLine($"Student's final assessment is {gradeAverage:f2}.");
        }
    }
}
