using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int length = inputArray.Length - 1;
            int[] condensedArray = new int[length];

            while (length > 0)
            {

                for (int i = 0; i < length; i++)
                {
                    condensedArray[i] = inputArray[i] + inputArray[i + 1];
                    //inputArray[i] = condensedArray[i];                           //remove comment, and add comment on second loop (but makes program slow)...
                }

                for (int i = 0; i < length; i++)
                {
                    inputArray[i] = condensedArray[i];
                }

                length--;
            }

            Console.WriteLine(inputArray[0]);
        }
    }
}
