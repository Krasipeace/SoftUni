using System;

namespace BirthdayParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rent = int.Parse(Console.ReadLine());

            double cake = rent * 0.20;
            double drinks = cake - (cake * 0.45);
            double animator = rent / 3;
            double spend = rent + cake + drinks + animator;

            Console.WriteLine(spend);
        }
    }
}
