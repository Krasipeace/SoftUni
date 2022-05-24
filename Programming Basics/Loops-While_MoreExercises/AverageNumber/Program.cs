using System;

namespace AverageNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numQ = int.Parse(Console.ReadLine());
            double numNum = numQ;
            double numbers = 0;
            int num;
            double average = 0.0;
            while (true)
            {
                if (numNum > 0)
                {
                    num = int.Parse(Console.ReadLine());
                    numbers += num;
                    numNum--;
                    
                }
                else
                {
                    break;
                }
            }
            average = numbers / numQ;
            Console.WriteLine($"{average:f2}");
        }
        
    }
}
