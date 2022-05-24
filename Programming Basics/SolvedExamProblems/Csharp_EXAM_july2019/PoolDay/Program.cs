using System;

namespace PoolDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double deckchair = double.Parse(Console.ReadLine());
            double umbrella = double.Parse(Console.ReadLine());

            double taxPpl = people * tax;
            double dcPpl = Math.Ceiling(people * 0.75);
            dcPpl = dcPpl * deckchair;
            double umbPpl = Math.Ceiling(people * 0.50);
            umbPpl = umbPpl * umbrella;
            double result = taxPpl + dcPpl + umbPpl;
            Console.WriteLine($"{result:f2} lv.");
        }
    }
}
