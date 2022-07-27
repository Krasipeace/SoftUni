using System;  // if the element in list has odd amount of element(Count) -> remove it
using System.Collections.Generic;
using System.Linq;

namespace Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers(divider-interval): ");

            List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            //Dictionary<int, List<int>> newList = new Dictionary<int, List<int>>();            

            //not a good solution
            var repeatedNumbers = list.GroupBy(x => x)
                                      .Select(num => new { KeyValuePair = num.Key, Count = num.Count() })
                                      .Where(num => num.Count % 2 == 0)                                      
                                      .OrderBy(x => x.Count);

            foreach (var item in repeatedNumbers)
            {
                Console.WriteLine(item);
            }



            //foreach (var item in newList)
            //{
            //    Console.Write($"{item} ");
            //}

            //foreach (var item in newList)
            //{
            //    Console.WriteLine($"{item.Key} -> {item.Value}");
            //}
        }
    }
}
