using System;

namespace TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            int allPeople = 0;
            double pplMusala = 0;
            double pplKili = 0;
            double pplMonblan = 0;
            double pplKtwo = 0;
            double pplEverest = 0;

            for (int i = 1; i <= groups; i++)
            {
                int pplInGroup = int.Parse(Console.ReadLine());
                allPeople += pplInGroup;
                if (pplInGroup <= 5)
                {
                    pplMusala += pplInGroup;
                }
                else if (pplInGroup <= 12)
                {
                    pplMonblan += pplInGroup;
                }
                else if (pplInGroup <= 25)
                {
                    pplKili += pplInGroup;
                }
                else if (pplInGroup <= 40)
                {
                    pplKtwo += pplInGroup;
                }
                else
                {
                    pplEverest += pplInGroup;
                }
            }
            double musala = pplMusala / allPeople * 100.0;
            double monblan = pplMonblan / allPeople * 100.0;
            double kili = pplKili / allPeople * 100.0;
            double kTwo = pplKtwo / allPeople * 100.0;
            double everest = pplEverest / allPeople * 100.0;

            Console.WriteLine($"{musala:f2}%");
            Console.WriteLine($"{monblan:f2}%");
            Console.WriteLine($"{kili:f2}%");
            Console.WriteLine($"{kTwo:f2}%");
            Console.WriteLine($"{everest:f2}%");
        }
    }
}
