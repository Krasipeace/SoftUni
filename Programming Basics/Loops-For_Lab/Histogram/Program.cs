using System;

namespace Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            double p1 = 0; // <200
            double p2 = 0; // 200 - 399 
            double p3 = 0; // 400 - 599
            double p4 = 0; // 600 - 799
            double p5 = 0; // >=800

            for (int i = 1; i <= numbers; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    p1 += 1;
                }
                else if (num <= 399)
                {
                    p2 += 1;
                }
                else if (num <= 599)
                {
                    p3 += 1;
                }
                else if (num <=799)
                {
                    p4 += 1;
                }
                else
                {
                    p5 += 1;
                }
            }
            p1 = p1 / numbers * 100.0;
            p2 = p2 / numbers * 100.0;
            p3 = p3 / numbers * 100.0;
            p4 = p4 / numbers * 100.0;
            p5 = p5 / numbers * 100.0;
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
