using System;

namespace zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string hex = "142CBD";
            double floatPos = 1324.20323;
            double floatNeg = -1324.3032133;

            Console.WriteLine($"{hex,0}" + $"{floatPos,17:f2}" + $"{floatNeg,17:f2}"); 
                  
        }
    }
}
