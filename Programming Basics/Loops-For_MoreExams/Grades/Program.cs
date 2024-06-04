using System;

namespace Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());
            double fStudent = 0.0;
            double eStudent = 0.0;
            double dStudent = 0.0;
            double topStudent = 0.0;
            double sumOfGrades = 0.0;

            for (int i = 1; i <= numOfStudents; i++)
            {
                double gradeOfStudent = double.Parse(Console.ReadLine());
                if (gradeOfStudent <= 2.99)
                {
                    fStudent += 1;
                }
                else if (gradeOfStudent <= 3.99)
                {
                    eStudent += 1;
                }
                else if (gradeOfStudent <= 4.99)
                {
                    dStudent += 1;
                }
                else
                {
                    topStudent += 1;
                }
                sumOfGrades += gradeOfStudent;
            }
            double averageOfGrades = sumOfGrades / numOfStudents;
            double pfStudent = fStudent / numOfStudents * 100.0;
            double peStudent = eStudent / numOfStudents * 100.0;
            double pdStudent = dStudent / numOfStudents * 100.0;
            double pTopStudent = topStudent / numOfStudents * 100.0;
            Console.WriteLine($"Top students: {pTopStudent:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {pdStudent:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {peStudent:f2}%");
            Console.WriteLine($"Fail: {pfStudent:f2}%");
            Console.WriteLine($"Average: {averageOfGrades:f2}");
        }
    }
}
