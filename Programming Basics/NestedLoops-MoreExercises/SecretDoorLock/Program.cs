using System;

namespace UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int digitOne = int.Parse(Console.ReadLine());
            int digitTwo = int.Parse(Console.ReadLine());
            int digitThree = int.Parse(Console.ReadLine());


            for (int i = 2; i <= digitOne; i += 2)
            {
                for (int j = 2; j <= digitTwo; j++)
                {
                    if (j == 2 || j == 3 || j == 5 || j == 7)

                        for (int k = 2; k <= digitThree; k += 2)
                        {
                            if (i % 2 == 0 && k % 2 == 0)
                            {
                                Console.WriteLine($"{i} {j} {k}");
                            }
                        }
                }
            }
        }
    }
}
