using System;

namespace Bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());           
            int water = 20 * months;
            int internet = 15 * months;
            double sumElec = 0.0;
            double other = 0.0;

            for (int i = 1; i <= months; i++)
            {
                double electricity = double.Parse(Console.ReadLine());
                sumElec += electricity;
                other += (electricity + 20 + 15) * 0.20;
            }
            double sumOther = sumElec + water + internet + other;
            double sumAll = sumElec + water + internet + sumOther;
            double average = sumAll / months;
            Console.WriteLine($"Electricity: {sumElec:f2} lv");
            Console.WriteLine($"Water: {water:f2} lv");
            Console.WriteLine($"Internet: {internet:f2} lv");
            Console.WriteLine($"Other: {sumOther:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");
                        
        }
    }
}
