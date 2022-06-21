using System;

namespace _1._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teacherOne = int.Parse(Console.ReadLine());
            int teacherTwo = int.Parse(Console.ReadLine());
            int teacherThree = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int counter = 0;            
            int answersPerHour = teacherOne + teacherTwo + teacherThree;
                     
            while (students > 0)
            {
                students -= answersPerHour;
                counter++;
                
                if (counter % 4 ==0)
                {
                    counter++;
                }
            }
            Console.WriteLine($"Time needed: {counter}h.");
        }
    }
}
