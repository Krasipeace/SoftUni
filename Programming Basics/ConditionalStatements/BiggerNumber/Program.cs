using System;

namespace BiggerNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            //num1>num2  num2>num1  num1==num2
            if (num1 > num2)
            {
                Console.WriteLine(num1);
            }
            else 
            {
                Console.WriteLine(num2);
            }
        }
    }
}
