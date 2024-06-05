using System;

namespace Sequence2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 1;
            while (counter <= number)
            {
                Console.WriteLine(counter);
                counter = (counter * 2) + 1;
            }
        }
    }
}
