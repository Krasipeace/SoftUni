using System;

namespace OscarsCeremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double statuettes = input - input * 0.30;
            double catering = statuettes - statuettes * 0.15;
            double sounding = catering / 2;
            double result = input + statuettes + sounding + catering;
            Console.WriteLine($"{result:f2}");
        }
    }
}
