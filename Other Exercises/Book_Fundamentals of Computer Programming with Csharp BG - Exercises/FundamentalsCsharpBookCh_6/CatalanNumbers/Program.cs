using System;

namespace CatalanNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 8
            // Result = (2n)! / ((n+1)! * n!)
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            int nx2 = n * 2;
            for (int i = nx2 - 1; i > 0; i--)
            {
                nx2 *= i;
            }
            int userN = n;
            for (int i = userN - 1; i > 0; i--)
            {
                userN *= i;
            }
            int nPlus = n + 1;
            for (int j = nPlus - 1; j > 0; j--)
            {
                nPlus *= j;
            }
            int result = nx2 / (n * nPlus);
            Console.WriteLine($"(2n)! / ((n+1)! * n!) = {result}");

        }
    }
}
