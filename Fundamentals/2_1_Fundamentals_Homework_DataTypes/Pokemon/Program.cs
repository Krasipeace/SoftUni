using System;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int pokeDistance = int.Parse(Console.ReadLine());
            byte pokeExhaustion = byte.Parse(Console.ReadLine());

            byte pokeTarget = 0;            
            double powerDivision = pokePower * 0.50;

            while (pokePower >= pokeDistance)
            {
                pokePower -= pokeDistance;
                pokeTarget++;
                if (pokePower == powerDivision && pokeExhaustion != 0)
                {
                    pokePower /= pokeExhaustion;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokeTarget);

            //unfinished
        }
    }
}
