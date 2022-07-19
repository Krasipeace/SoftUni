using System;

namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];
            int result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
                result = array[i] * 5;

                Console.Write(result + " ");
            }
        }
    }
}
