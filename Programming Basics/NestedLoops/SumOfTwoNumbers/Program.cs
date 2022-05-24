using System;

namespace SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int counter = 0;
            bool found = false;

            for (int i = numOne; i <= numTwo; i++)
            {
                for (int j = numOne; j <= numTwo; j++)
                {
                    counter++;
                    if (i + j == magicNum)
                    {                        
                        numOne = i;
                        numTwo = j;
                        found = true;
                        Console.WriteLine($"Combination N:{counter} ({numOne} + {numTwo} = {magicNum})");
                        break;
                    }                    
                }
                if (found)
                {
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}
