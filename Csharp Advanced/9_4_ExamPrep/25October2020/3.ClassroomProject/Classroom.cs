using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;
        public Classroom(int capacity)
        {
            this.Students = new List<Student>();
            this.Capacity = capacity;
        }
        public List<Student> Students { get { return students; } set { students = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student regStudent)
        {
            if (this.Count != this.Capacity)
            {
                this.Students.Add(regStudent);

                return $"Added student {regStudent.FirstName} {regStudent.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.Students.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                this.Students.Remove(this.Students.Find(s => s.FirstName == firstName && s.LastName == lastName));

                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            if (!this.Students.Any(s => s.Subject == subject))
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (Student student in Students.Where(s => s.Subject == subject))
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName) => this.Students.Find(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
