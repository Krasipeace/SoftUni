using System;

namespace InchToCm
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());        
            double b = a * 2.54;
            Console.WriteLine(b);
        }
    }
}