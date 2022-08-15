using System;
using System.Collections.Generic;

namespace _3._DecToBin_Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            string binaryNumber = string.Empty;
            Stack<int> result = new Stack<int>();

            if (decimalNumber == 0)
            {
                Console.WriteLine("0");

                return;
            }

            while (decimalNumber > 0)
            {
                result.Push(decimalNumber % 2);
                decimalNumber /= 2;
            }

            while (result.Count > 0)
            {
                binaryNumber += result.Pop().ToString();
            }
            Console.WriteLine(binaryNumber);
        }
    }
}
