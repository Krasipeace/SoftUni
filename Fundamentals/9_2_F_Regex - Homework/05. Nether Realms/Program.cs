using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternHealth = @"[^\.\+\-\/\*0-9\s]";
            string patternDamage = @"-?\d+\.?\d*";
            string patternMultiplyDivide = @"[\*\/]";
            string patternSplitInput = @"[,\s]+";

            string input = Console.ReadLine();
            string[] demons = Regex.Split(input, patternSplitInput).OrderBy(x => x).ToArray();

            for (int i = 0; i < demons.Length; i++)
            {
                string currentDemon = demons[i];

                MatchCollection matchesHealth = Regex.Matches(currentDemon, patternHealth);
                int health = 0; //initial demon health                
                foreach (Match currDemon in matchesHealth) //calculating demon health
                {
                    char currentSymbol = char.Parse(currDemon.ToString());
                    health += currentSymbol;
                }

                MatchCollection matchesDamage = Regex.Matches(currentDemon, patternDamage);
                double damage = 0.0; //initial demon damage
                foreach (Match currDemon in matchesDamage) //calculating demon damage
                {
                    double currentDamage = double.Parse(currDemon.ToString());
                    damage += currentDamage;
                }

                MatchCollection matchesMultiplyDivide = Regex.Matches(currentDemon, patternMultiplyDivide);
                foreach (Match multiplyOrDivide in matchesMultiplyDivide)
                {
                    char currentOperator = char.Parse(multiplyOrDivide.ToString());
                    if (currentOperator == '*')
                    {
                        damage *= 2;
                    }
                    else if (currentOperator == '/')
                    {
                        damage /= 2;
                    }
                }

                Console.WriteLine($"{currentDemon} - {health} health, {damage:f2} damage");

            }
        }
    }
}
