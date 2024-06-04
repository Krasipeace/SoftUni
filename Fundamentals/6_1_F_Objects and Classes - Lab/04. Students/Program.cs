using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string [] tokens = command.Split();
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string city = tokens[3];

                Student student = new Student();
                {
                    student.FirstName = firstName; 
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;
                }
                students.Add(student);
                command = Console.ReadLine();
            }

            string filterCity = Console.ReadLine();
            List<Student> filteredStudents = students.Where(s => s.City == filterCity).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
