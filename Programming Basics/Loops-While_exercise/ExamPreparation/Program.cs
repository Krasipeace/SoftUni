using System;

namespace ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int failedTries = int.Parse(Console.ReadLine());
            int failTimes = 0;
            int solvedTasks = 0;
            double sumGrades = 0.0;
            string lastTask = "";
            bool success = false;
            while (failTimes < failedTries)
            {
                string task = Console.ReadLine();
                if (task == "Enough")
                {
                    success = true;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    failTimes += 1;                    
                }
                sumGrades += grade;
                solvedTasks++;
                lastTask = task;                
            }
            if (success)
            {
                Console.WriteLine($"Average score: {sumGrades / solvedTasks:f2}");
                Console.WriteLine($"Number of problems: {solvedTasks}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
            else
            {
                Console.WriteLine($"You need a break, {failedTries} poor grades.");
            }
        }
    }
}
