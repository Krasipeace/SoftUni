using System;
using System.Linq;

namespace Problem_11
{  // {4, 3, 1, 4, 2, 5, 8} userNumber = 11 >>>> sequenceResult =  {4, 2, 5}. 4+2+5=11
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter userNumber: ");
            int userNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter array of numbers: ");
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            if (arr.Length > 0)
            {             

                int sameSumStartIndex; 
                int sameSumEndIndex;
                sameSumStartIndex = sameSumEndIndex = 0;
                bool isSumFound = false;

                for (int startIndex = 0; startIndex < arr.Length && !isSumFound; startIndex++)
                {
                    int sum = 0;

                    for (int endIndex = startIndex; endIndex < arr.Length && !isSumFound; endIndex++)
                    {
                        sum += arr[endIndex];

                        if (sum == userNumber)
                        {
                            sameSumStartIndex = startIndex;
                            sameSumEndIndex = endIndex;
                            isSumFound = true;
                        }
                    }
                }

                if (isSumFound)
                {
                    Console.Write("The following sequence equals userNumber: ");

                    for (int i = sameSumStartIndex;i <= sameSumEndIndex; i++)
                    {
                        Console.Write(arr[i] + " ");
                    }
                }
                else
                {
                    Console.WriteLine("There is no sequence, that equals userNumber!");
                }
            }
        }

    }
}

