using System;

namespace MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxNumber = int.MinValue;
            while (input != "Stop")
            {
                int numInput = int.Parse(input);
                if (numInput > maxNumber)
                {
                    maxNumber = numInput;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxNumber);
        }
    }
}
