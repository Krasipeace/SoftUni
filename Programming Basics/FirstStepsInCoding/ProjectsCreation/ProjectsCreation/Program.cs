using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameArch = Console.ReadLine();
            int projectsNum = int.Parse(Console.ReadLine());
            int hoursOfWork = 3 * projectsNum;
            Console.WriteLine($"The architect {nameArch} will need {hoursOfWork} hours to complete {projectsNum} project/s.");
        }
    }
}