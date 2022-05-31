using System;
using System.Numerics;

namespace DivideOfFactoriels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Combination of task 6 and task 7

            //Програма, която пресмята N!/K! за дадени N и K (1<K<N).

            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());

            for (int i = n - 1; i > 0; i--)
            {
                n = n * i;
            }
            for (int i = k - 1; i > 0; i--)
            {
                k = k * i;
            }
            Console.WriteLine($"N! = {n} K! = {k}");
            int ndivk = n / k;
            Console.WriteLine($"N!/K! = {ndivk}");

            //Програма, която пресмята N!*K!/(N-K)! за дадени N и K (1<K<N).
            BigInteger nk = n - k; 
            for (BigInteger j = nk - 1; j > 0; j--)
            {
                nk = nk * j;
            }
            BigInteger nkResult = (n * k) / (nk);
            Console.WriteLine($"N! * K! / (N - K)! = {nkResult}");


        }
    }
}
