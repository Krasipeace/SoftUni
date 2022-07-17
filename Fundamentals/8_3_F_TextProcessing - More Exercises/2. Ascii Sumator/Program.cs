using System;
using System.Text;

namespace _2._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char inputOne = char.Parse(Console.ReadLine());
            char inputTwo = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            int startIndex = Math.Min(inputOne, inputTwo);
            int lastIndex = Math.Max(inputOne,inputTwo);

            int sumOfSymbols = 0;

            for (int i = 0; i < text.Length; i++)
            {
                int currentSymbol = (char)text[i];
                if (currentSymbol > startIndex && currentSymbol < lastIndex)
                {
                    sumOfSymbols += (char)text[i];
                }
            }
            Console.WriteLine(sumOfSymbols);
        }
    }
}
