using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> info = new Dictionary<string, List<double>>();
            int num = int.Parse(Console.ReadLine());
            const double NEEDED_GRADE = 4.50;

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!info.ContainsKey(name))
                {
                    info[name] = new List<double>();
                }
                info[name].Add(grade);
            }

            foreach (var item in info.Where(item => item.Value.Average() >= NEEDED_GRADE))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
