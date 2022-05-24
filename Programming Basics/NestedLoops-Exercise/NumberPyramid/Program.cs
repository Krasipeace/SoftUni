using System;

namespace NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int counter = 1;
            bool big = false;
            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (counter > num)
                    {
                        big = true;
                        break;
                    }
                    Console.Write(counter + " ");
                    counter++;
                }
                if (big)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
