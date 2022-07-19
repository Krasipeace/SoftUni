using System;
using System.Linq;

namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] arrayOne, arrayTwo;
            ReadArrays(out arrayOne, out arrayTwo);

            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);

            if (arrayOne.Length != arrayTwo.Length)
            {
                Console.WriteLine("Enter Two Arrays with equal elements!");

                ReadArrays(out arrayOne, out arrayTwo);
            }
            else
            {
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (arrayOne[i] < arrayTwo[i])
                    {
                        Console.WriteLine("Array One is First!");

                        break;
                    }
                    else if (arrayOne[i] > arrayTwo[i])
                    {
                        Console.WriteLine("Array Two is First!");

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Arrays have equal values of their elements!");

                        break;
                    }
                }
            }
        }

        private static void ReadArrays(out char[] arrayOne, out char[] arrayTwo)
        {
            Console.WriteLine("Enter Two Arrays with equal elements!");
            Console.Write("Enter elements of array One: ");
            arrayOne = Console.ReadLine().Split().Select(char.Parse).ToArray();
            Console.Write("Enter elements of array Two: ");
            arrayTwo = Console.ReadLine().Split().Select(char.Parse).ToArray();
            Console.WriteLine();
        }
    }
}
