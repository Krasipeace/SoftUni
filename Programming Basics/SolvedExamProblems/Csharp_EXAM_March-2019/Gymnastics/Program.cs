using System;

namespace Gymnastics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string equipment = Console.ReadLine();

            double grade = 0;

            if (country == "Russia")
            {
                if (equipment == "ribbon")
                {
                    grade = 9.1 + 9.4;
                }
                else if (equipment == "hoop")
                {
                    grade = 9.3 + 9.8;
                }
                else if (equipment == "rope")
                {
                    grade = 9.6 + 9.0;
                }
            }
            else if (country == "Bulgaria")
            {
                if (equipment == "ribbon")
                {
                    grade = 9.6 + 9.4;
                }
                else if (equipment == "hoop")
                {
                    grade = 9.550 + 9.750;
                }
                else if (equipment == "rope")
                {
                    grade = 9.5 + 9.4;
                }
            }
            else if (country == "Italy")
            {
                if (equipment == "ribbon")
                {
                    grade = 9.2 + 9.5;
                }
                else if (equipment == "hoop")
                {
                    grade = 9.450 + 9.350;
                }
                else if (equipment == "rope")
                {
                    grade = 9.700 + 9.150;
                }
            }
            double pNumber = 20.0 - grade;
            double pGrade = pNumber / 20 * 100;
            Console.WriteLine($"The team of {country} get {grade:f3} on {equipment}.");
            Console.WriteLine($"{pGrade:f2}%");
        }
    }
}
