using System; //count numbers in List
using System.Collections.Generic;
using System.Linq;

namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers(divider-interval): ");

            List<int> list = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var repeatedNumbers = list.GroupBy(x => x)
                                            .Select(num => new {Value = num.Key, Count = num.Count()})
                                            .OrderBy(x => x.Count);

            foreach (var item in repeatedNumbers)
            {
                Console.WriteLine($"{item.Value} -> {item.Count}");
            }
        }
    }
}
