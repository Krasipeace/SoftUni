using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Even_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray();
            int start = range[0];
            int end = range[1];
            string command = Console.ReadLine();

            List<int> numbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }
            switch (command)
            {
                case "even":
                    IEnumerable even = numbers.Where(n => n % 2 == 0);
                    foreach (var item in even)
                    {
                        Console.Write($"{item} ");
                    }
                    break;
                case "odd":
                    IEnumerable odd = numbers.Where(n => n % 2 != 0);                                    
                    foreach (var item in odd)
                    {
                        Console.Write($"{item} ");
                    }
                    break;
            }          
        }
    }
}
