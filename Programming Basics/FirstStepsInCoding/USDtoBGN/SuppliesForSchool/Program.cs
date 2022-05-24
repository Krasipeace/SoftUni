using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            //четем 4 входа от конзолата и ги запазваме
            int pencilCount = int.Parse(Console.ReadLine());
            int markersCount = int.Parse(Console.ReadLine());
            int preparationCount = int.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());
            //изчисление на продуктите
            double pencilPrice = pencilCount * 5.80;
            double markersPrice = markersCount * 7.20;
            double preparationPrice = preparationCount * 1.20;
            //общата сума
            double sum = pencilPrice + markersPrice + preparationPrice;
            //от общата сума - изваждаме процента намаление
            double totalSum = sum - sum * (percent / 100.0);
            //отпечатване на резултата
            Console.WriteLine(totalSum);
        }
    }
}