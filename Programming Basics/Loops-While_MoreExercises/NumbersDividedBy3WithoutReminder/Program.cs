using System;

namespace NumbersDividedBy3WithoutReminder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int num = 1; num <= 100; num++)
            {
                while (num % 3 == 0)
                {
                    Console.WriteLine(num);
                    num++;
                }
            }
        }
    }
}
