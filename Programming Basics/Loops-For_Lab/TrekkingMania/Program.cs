using System;

namespace TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            int numberOfPpl = 0;

            double pMusala = 0;
            double pMonblan = 0;
            double pKili = 0;
            double pKtwo = 0;
            double pEverest = 0;

            for (int i = 1; i <= numberOfGroups; i++)
            {
                int pplInGroups = int.Parse(Console.ReadLine());
                numberOfPpl += pplInGroups;
                if (pplInGroups <= 5)
                {
                    pMusala += pplInGroups;
                }
                else if (pplInGroups <= 12)
                {
                    pMonblan += pplInGroups;
                }
                else if (pplInGroups <= 25)
                {
                    pKili += pplInGroups;
                }
                else if (pplInGroups <=40)
                {
                    pKtwo += pplInGroups;
                }
                else
                {
                    pEverest += pplInGroups;
                }
            }
            pMusala = pMusala / numberOfPpl * 100.0; 
            pMonblan = pMonblan / numberOfPpl * 100.0; 
            pKili = pKili / numberOfPpl * 100.0;
            pKtwo = pKtwo / numberOfPpl * 100.0;
            pEverest = pEverest / numberOfPpl * 100.0;
            Console.WriteLine($"{pMusala:f2}%");
            Console.WriteLine($"{pMonblan:f2}%");
            Console.WriteLine($"{pKili:f2}%");
            Console.WriteLine($"{pKtwo:f2}%");
            Console.WriteLine($"{pEverest:f2}%");
        }
    }
}
