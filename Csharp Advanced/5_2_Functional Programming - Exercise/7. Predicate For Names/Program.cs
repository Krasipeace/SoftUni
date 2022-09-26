using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthName = int.Parse(Console.ReadLine());
            List<string> names = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Func<List<string>, List<string>> getLengthNames = list => list.Where(n => n.Length <= lengthName).ToList();
            Action<List<string>> print = list => Console.WriteLine(string.Join("\n", list));

            names = getLengthNames(names);
            print(names);
        }
    }
}
