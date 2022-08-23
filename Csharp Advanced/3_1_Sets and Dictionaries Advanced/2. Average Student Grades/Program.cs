using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<decimal>>();

            int studentInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentInputs; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>() { grade });
                }
                else
                {
                    students[name].Add(grade);
                }
            }
            
            foreach (var item in students)
            {
                Console.Write($"{item.Key} -> ");
                foreach (decimal currGrade in item.Value)
                {
                    Console.Write($"{currGrade:f2} ");
                }
                Console.Write($"(avg: {item.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
