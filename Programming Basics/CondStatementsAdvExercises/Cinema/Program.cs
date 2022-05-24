using System;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //четем от конзолата
            string ticketType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            //изчисляваме броят на местата в залата
            double income = rows * columns;
            //проверяваме тип на билетите
            if (ticketType == "Premiere")
            {
                income = income * 12.00;
            }
            else if (ticketType == "Normal")
            {
                income = income * 7.50;
            }
            else
            {
                income = income * 5.00;
            }
            //изчисляваме приходите от билетите
            Console.WriteLine($"{income:F2} leva");



        }
    }
}
