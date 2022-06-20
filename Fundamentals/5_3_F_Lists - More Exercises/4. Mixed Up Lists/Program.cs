using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Mixed_Up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int checkSmallList = Math.Min(firstList.Count, secondList.Count);

            List<int> combinedInputList = new List<int>(checkSmallList);
            secondList.Reverse();

            CheckLists(firstList, secondList, checkSmallList, combinedInputList);
        }

        private static void CheckLists(List<int> firstList, List<int> secondList, int checkSmallList, List<int> combinedInputList)
        {
            for (int i = 0; i < checkSmallList; i++)
            {
                combinedInputList.Add(firstList[i]);
                combinedInputList.Add(secondList[i]);
            }

            int constraintOne = 0;
            int constraintTwo = 0;

            if (firstList.Count > secondList.Count)
            {
                constraintOne = firstList[firstList.Count - 1];
                constraintTwo = firstList[firstList.Count - 2];
            }
            else
            {
                constraintOne = secondList[secondList.Count - 1];
                constraintTwo = secondList[secondList.Count - 2];
            }

            FinalizeAndPrintResult(combinedInputList, constraintOne, constraintTwo);
        }

        private static void FinalizeAndPrintResult(List<int> combinedInputList, int constraintOne, int constraintTwo)
        {
            int smallerConstraintNum = Math.Min(constraintOne, constraintTwo);
            int biggerConstraintNum = Math.Max(constraintOne, constraintTwo);
            List<int> listToPrint = new List<int>(20);

            listToPrint = combinedInputList.Where(n => n > smallerConstraintNum && n < biggerConstraintNum).ToList();

            listToPrint.Sort();

            Console.WriteLine(string.Join(" ", listToPrint));
        }
    }
}
