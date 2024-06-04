using System;
using System.Linq;

namespace _2.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOne = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] arrayTwo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] commonElements = arrayTwo.Intersect(arrayOne).ToArray();

            foreach (var element in commonElements)
            {
                Console.Write($"{element} ");
            }  
        }
    }
}
