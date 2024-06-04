using System;
using System.Linq;

namespace _4.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            int key = int.Parse(Console.ReadLine());

            for (int i = 0; i < key; i++)
            {
                int keyElement = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = keyElement;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
