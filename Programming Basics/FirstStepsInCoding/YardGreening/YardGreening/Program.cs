using System;
namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double greenYards = double.Parse(Console.ReadLine());
            double fullPrice = 7.61 * greenYards;
            double discount = fullPrice * 0.18;
            double finalPrice = fullPrice - discount;
            Console.WriteLine($"The Final Price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}