using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            List<string> names = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Func<string, int, bool> isWordMorePoints = (word, asciiPoints) => word.ToCharArray().Select(ch => (int)ch).Sum() >= asciiPoints;
            Func<List<string>, int, Func<string, int, bool>, string> wordBestPoints = (list, asciiPoints, func) => list.FirstOrDefault(word => func(word, asciiPoints));

            Action<string> print = str => Console.WriteLine(str);

            string printName = wordBestPoints(names, points, isWordMorePoints);
            print(printName);
        }
    }
}
