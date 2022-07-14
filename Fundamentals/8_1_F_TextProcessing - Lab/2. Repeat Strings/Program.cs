using System;
using System.Text;

namespace _2._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder repeatWord = new StringBuilder();

            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    repeatWord.Append(item);
                }
            }

            Console.WriteLine(repeatWord.ToString());
        }
    }
}
