using System;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Кои от следните стойности може да се присвоят на променливи от тип float, double и decimal: 34.567839023; 12.345; 8923.1234857; 3456.091124875956542151256683467 ?
            float numberFloat1 = 12.345f;
            float numberFloat2 = 8923.1234567f;
            double numberDouble1 = 34.567839023;
            decimal numberDecimal1 = 3456.091124875956542151256683467m;

            Console.WriteLine(numberFloat1);
            Console.WriteLine(numberFloat2);
            Console.WriteLine(numberDouble1);
            Console.WriteLine(numberDecimal1);
        }
    }
}