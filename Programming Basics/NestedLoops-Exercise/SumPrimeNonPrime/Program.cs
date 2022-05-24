using System;

namespace SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int checkNum = 0;
            int sumPrime = 0;
            int sumNonPr = 0;
            bool primeChk;

            while (input != "stop")
            {
                primeChk = true;
                checkNum = int.Parse(input);
                if (checkNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                for (int i = 2; i < checkNum; i++)
                {
                    if (checkNum % i == 0)
                    {
                        primeChk = false;
                        break;
                    }                                       
                }
                if (checkNum > 0)
                {
                    if (primeChk)
                    {
                        sumPrime += checkNum;
                    }
                    else
                    {
                        sumNonPr += checkNum;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPr}");
        }
    }
}
