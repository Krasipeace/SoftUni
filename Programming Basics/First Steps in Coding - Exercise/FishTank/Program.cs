using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            //4 входа
            //1. Дължина в см – цяло число в интервала [10 … 500]
            //2.Широчина в см – цяло число в интервала[10 … 300]
            //3.Височина в см – цяло число в интервала[10… 200]
            //4.Процент – реално число в интервала[0.000 … 100.000]
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent =  double.Parse(Console.ReadLine());

            //изчисляваме обем на аквариума
            double volume = length * width * height;
            //изчисляваме обема в литри
            double volumeInLiters = volume / 1000;
            //изчисляваме каква част от аквариума е заета
            double busy = percent / 100;
            //изчисляваме колко вода трябва да се налее
            double liters = volumeInLiters * (1 - busy);
            //отпечатваме резултата на конзолата
            Console.WriteLine(liters);
        }
    }
}