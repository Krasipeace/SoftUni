using System;

namespace _2.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintInWords(double.Parse(Console.ReadLine()));
        }

        private static void PrintInWords(double grade)
        {
            string gradeInWords = string.Empty;

            if (grade <= 2.99)
            {
                gradeInWords = "Fail";
            }
            else if (grade <= 3.49)
            {
                gradeInWords = "Poor";
            }
            else if (grade <= 4.49)
            {
                gradeInWords = "Good";
            }
            else if (grade <= 5.49)
            {
                gradeInWords = "Very good";
            }
            else if (grade <= 6.00)
            {
                gradeInWords = "Excellent";
            }
            Console.WriteLine(gradeInWords);
        }
    }
}
