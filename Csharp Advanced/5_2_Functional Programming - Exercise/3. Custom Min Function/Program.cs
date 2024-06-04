using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

            if (numbers.Length != 0)
            {
                Console.WriteLine(((Func<int[], int>)(array =>
                {
                    int number = array[0];
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (number > array[i])
                        {
                            number = array[i];
                        }
                    }

                    return number;
                }))(numbers));
            }
        }
    }
}
