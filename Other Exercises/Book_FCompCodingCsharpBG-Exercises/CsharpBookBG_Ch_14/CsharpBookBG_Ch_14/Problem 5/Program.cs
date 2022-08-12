using System;
using System.Collections.Generic;

namespace Problem_5
{
    internal class Student
    {
        private Student(string name, string course, string subject, string univercity, string email, string phoneNumber)
        {
            Name = name;
            Course = course;
            Subject = subject;
            Univercity = univercity;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        private string Name { get; set; }
        private string Course { get; set; }
        private string Subject { get; set; }
        private string Univercity { get; set; }
        private string Email { get; set; }
        private string PhoneNumber { get; set; }
        private void PrintStudent()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Course: {Course}");
            Console.WriteLine($"Subject: {Subject}");
            Console.WriteLine($"Univercity: {Univercity}");
            Console.WriteLine($"E-mail: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            Console.Write("Enter number of students to add to the list: ");
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                Console.Write("Enter full name: ");
                string name = Console.ReadLine();
                Console.Write("Enter course: ");
                string course = Console.ReadLine();
                Console.Write("Enter subject: ");
                string subject = Console.ReadLine();
                Console.Write("Enter univercity: ");
                string univercity = Console.ReadLine();
                Console.Write("Enter e-mail: ");
                string email = Console.ReadLine();
                Console.Write("Enter phone number: ");
                string phoneNumber = Console.ReadLine();

                Student student = new Student(name, course, subject, univercity, email, phoneNumber)
                {
                    Name = name,
                    Course = course,
                    Subject = subject,
                    Univercity = univercity,
                    Email = email,
                    PhoneNumber = phoneNumber,
                };
                students.Add(student);
            }

            Console.WriteLine("Students: ");
            foreach (var item in students)
            {
                item.PrintStudent();
            }
        }
    }
}

