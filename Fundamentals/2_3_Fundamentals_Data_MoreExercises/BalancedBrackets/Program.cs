using System;

namespace BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte inputLines = byte.Parse(Console.ReadLine());
            byte counterOpenBracket = 0;
            byte counterCloseBracket = 0;
            for (int i = 1; i <= inputLines; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    counterOpenBracket++;
                }
                else if (input == ")")
                {
                    counterCloseBracket++;
                    if (counterOpenBracket - counterCloseBracket != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
            }
            if (counterOpenBracket == counterCloseBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
