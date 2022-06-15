using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listResult = new List<int>();

            for (int i = 0; i < Math.Min(listOne.Count, listTwo.Count); i++)
            {
                Console.Write($"{listOne[i]} {listTwo[i]} ");
            }

            if (listOne.Count > listTwo.Count)
            {
                listResult.AddRange(GetRemainingElements(listOne, listTwo));
            }
            else if (listTwo.Count > listOne.Count)
            {
                listResult = GetRemainingElements(listTwo, listOne);
            }

            Console.WriteLine(String.Join(" ", listResult));
        }

        static List<int> GetRemainingElements(List<int> longerList, List<int> shorterList)
        {
            List<int> numbers = new List<int>();

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                numbers.Add(longerList[i]);
            }
            return numbers;
        }
    }
}
