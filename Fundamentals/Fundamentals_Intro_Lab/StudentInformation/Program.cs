using System;

namespace StudentInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            Console.Write($"Name: {studentName}, Age: {age}, Grade: {grade:f2}");
        }
    }
}
