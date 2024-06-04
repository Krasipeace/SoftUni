using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    internal class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        string FirstName { get; set; }
        string LastName { get; set; }
        double Grade { get; set; }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int command = int.Parse(Console.ReadLine());

            for (int i = 0; i < command; i++)
            {
                List<string> studentInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string firstName = studentInput[0];
                string lastName = studentInput[1];
                double grade = double.Parse(studentInput[2]);

                students.Add(new Student(firstName, lastName, grade));
            }

            List<Student> sortedByGrade = students.OrderByDescending(descendingGrade => descendingGrade.Grade).ToList();

            foreach (var eachStudent in sortedByGrade)
            {
                Console.WriteLine($"{eachStudent.FirstName} {eachStudent.LastName}: {eachStudent.Grade:f2}");
            }
        }
    }
}


