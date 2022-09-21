using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            int inputNumbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(number))
                {
                    dictionary.Add(number, 0);
                }
                dictionary[number]++;
            }
            
            Console.WriteLine(dictionary.Single(n => n.Value % 2 == 0).Key);

            //foreach (var num in dictionary)
            //{
            //    if (num.Value %  2 == 0)
            //    {
            //        Console.WriteLine(num.Key);

            //        return;
            //    }
            //}

        }
    }
}
