using System;
namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double costOfFood = (dogFood * 2.50) + (catFood * 4);
            Console.WriteLine($"{ costOfFood} lv.");
        }
    }
}