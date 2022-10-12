using System;
using System.Linq;

namespace CustomComparator
{
    public class CustomComparator
    {
        static void Main(string[] args)
        {
            int[] list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, int, int> customComparator = (numberOne, numberTwo) =>
            {
                if (numberOne % 2 == 0 && numberTwo % 2 != 0)
                {
                    return -1;
                }
                else if (numberOne % 2 != 0 && numberTwo % 2 == 0)
                {
                    return 1;
                }

                return numberOne.CompareTo(numberTwo);
            };

            Array.Sort(list, (numOne, numTwo) => customComparator(numOne, numTwo));

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
