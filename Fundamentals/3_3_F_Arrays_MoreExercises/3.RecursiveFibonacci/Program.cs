using System;

namespace _3.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Фибоначи: (0), 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, ...

            int input = int.Parse(Console.ReadLine());
            int[] fiboArray = new int[input];
            int fiboNumber = 2;
            bool isBigFibo = false;

            if (input >= 2)
            {
                isBigFibo = true;
                fiboArray[0] = 0;
                fiboArray[1] = 1;
                for (int i = 2; i < fiboArray.Length - 1; i++)
                {
                    fiboArray[i] = fiboArray[i - 2] + fiboArray[i - 1];
                    fiboNumber += fiboArray[i];
                }
            }
            else
            {
                isBigFibo = false;
            }
            if (isBigFibo)
            {
                Console.WriteLine(fiboNumber);
            }
            else 
            {                
                Console.WriteLine(input);                
            }

            //index checker
            //int counter = 0;
            //foreach  (int number in fiboArray)
            //{
            //    counter++;
            //}
            //Console.WriteLine(counter);
        }
    }
}
