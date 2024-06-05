using System;

namespace BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //четем от конзолата - таксата за 1 година
            double taxPerYear = double.Parse(Console.ReadLine());
            //кецове – цената им е 40% по-малка от таксата за една година
            //екип – цената му е 20 % по - евтина от тази на кецовете
            //топка – цената ѝ е 1 / 4 от цената на баскетболния екип
            //аксесоари – цената им е 1 / 5 от цената на баскетболната топка
            double shoesPrice = taxPerYear - (taxPerYear * (40 / 100.0));
            double outfitPrice = shoesPrice - (shoesPrice * (20 / 100.0));
            double ballPrice = outfitPrice / 4;
            double accPrice = ballPrice / 5;
            //обща сума: таксата + кецове + екип + топка + аксесоари
            double sum = taxPerYear + shoesPrice + outfitPrice + ballPrice + accPrice;
            //отпечатваме сумата от конзолата
            Console.WriteLine(sum);
        }
    }
}