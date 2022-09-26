using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            List<int> dividingSequence = new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(num => int.Parse(num)).ToList());

            Console.WriteLine(string.Join(" ", ((Func<List<int>, int, IEnumerable<int>>)((dividingSequence, endOfRange) =>
                {
                    List<int> numbersDividedByTheSequence = new List<int>();

                    for (int number = 1; number <= endOfRange; number++)
                    {
                        if (dividingSequence.All(div => number % div == 0))
                        {
                            numbersDividedByTheSequence.Add(number);
                        }
                    }

                    return numbersDividedByTheSequence;
                }))(dividingSequence, endOfRange)));
        }
    }
}
