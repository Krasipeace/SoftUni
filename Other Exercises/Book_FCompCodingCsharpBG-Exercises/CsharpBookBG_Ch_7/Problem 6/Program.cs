using System;
using System.Linq;

namespace Problem_6
{
    //{9, 6, 2, 7, 4, 7, 6, 5, 8, 4} >>>> {2, 4, 6, 8}
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int tempIndex = 0;
            int tempCounter = 0;

            Console.Write("Enter numbers: ");
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int[] temp = new int[array.Length];
                tempIndex = tempCounter = 1;
                temp[0] = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > temp[tempIndex - 1])
                    {
                        temp[tempIndex] = array[j];
                        tempIndex++;
                        tempCounter++;
                    }
                    else if (tempIndex > 1 && array[j] > temp[tempIndex - 2] && array[j] < temp[tempIndex - 1])
                    {
                        temp[tempIndex - 1] = array[j];
                    }
                }

                if (counter < tempCounter)
                {
                    counter = tempCounter;
                    result = temp;
                }
            }

            for (int i = 0; i < counter; i++)
            {
                Console.Write(string.Join(" ", result[i]));
            }
        }
    }
}
