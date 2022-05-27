using System;

namespace ConvertMtoKM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());            
            decimal km = Convert.ToDecimal(meters / 1000.0);
            Console.WriteLine($"{km:f2}");
        }
    }
}
