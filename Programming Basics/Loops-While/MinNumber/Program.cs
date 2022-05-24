using System;

namespace MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNumber = int.MaxValue;
            while (input != "Stop")
            {
                int numInput = int.Parse(input);
                if (numInput < minNumber)
                {
                    minNumber = numInput;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(minNumber);
        }
    }
}

