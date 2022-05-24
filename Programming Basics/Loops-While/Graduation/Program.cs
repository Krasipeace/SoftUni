using System;

namespace Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double sum = 0.0;
            int grades = 1;
            int exclude = 0;
            while (grades <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.00)
                {
                    exclude += 1;
                    if (exclude >= 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {grades} grade");
                        break;
                    }
                    continue;
                }                                
                sum += grade;                                    
                grades += 1;
            }
            double average = sum / 12;
            if (exclude == 0)
            {
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
            }
        }
    }
}
