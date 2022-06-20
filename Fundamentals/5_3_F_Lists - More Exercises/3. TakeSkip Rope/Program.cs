using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._TakeSkip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            StringBuilder result = new StringBuilder();
            List<string> nonNumbers = new List<string>();

            NumbersOrChars(word, numbers, nonNumbers);
            TakeOrSkip(numbers, takeList, skipList);

            int indexForSkip = 0;

            indexForSkip = Decrypting(takeList, skipList, result, nonNumbers, indexForSkip);

            Console.WriteLine(result.ToString());
        }

        private static void NumbersOrChars(string word, List<int> numbers, List<string> nonNumbers)
        {
            foreach (char indexItem in word)
            {
                if (char.IsDigit(indexItem))
                {
                    numbers.Add(int.Parse(indexItem.ToString()));
                }
                else
                {
                    nonNumbers.Add(indexItem.ToString());
                }
            }
        }

        private static void TakeOrSkip(List<int> numbers, List<int> takeList, List<int> skipList)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }
        }

        private static int Decrypting(List<int> takeList, List<int> skipList, StringBuilder result, List<string> nonNumbers, int indexForSkip)
        {
            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(nonNumbers);

                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();
                result.Append(string.Join("", temp));
                indexForSkip += takeList[i] + skipList[i];
            }
            return indexForSkip;
        }

    }
}
