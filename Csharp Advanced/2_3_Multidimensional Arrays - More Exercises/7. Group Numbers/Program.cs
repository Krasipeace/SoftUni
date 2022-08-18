using System;
using System.Collections.Generic;

namespace _7._Group_Numbers //"jaggedwannabe"
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            List<int> remainderOne = new List<int>();
            List<int> remainderTwo = new List<int>();
            List<int> remainderThree = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                int currNum = int.Parse(input[i]);
                if (currNum % 3 == 1 || currNum % 3 == -1)
                {
                    remainderOne.Add(currNum);
                }
                if (currNum % 3 == 2 || currNum % 3 == -2)
                {
                    remainderTwo.Add(currNum);
                }
                if (currNum % 3 == 0)
                {
                    remainderThree.Add(currNum);
                }
            }
            foreach (var item in remainderThree)
            {
                Console.Write($"{string.Join(" ", item)} ");
            }
            Console.WriteLine();
            foreach (var item in remainderOne)
            {
                Console.Write($"{string.Join(" ", item)} ");
            }
            Console.WriteLine();
            foreach (var item in remainderTwo)
            {
                Console.Write($"{string.Join(" ", item)} ");
            }
        }
    }
}
