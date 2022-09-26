using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();
            int divider = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> divide = list => list.Where(number => (number % divider != 0)).Select(number => number).Reverse().ToList(); 
            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            numbers = divide(numbers);
            print(numbers);
        }
    }
}
