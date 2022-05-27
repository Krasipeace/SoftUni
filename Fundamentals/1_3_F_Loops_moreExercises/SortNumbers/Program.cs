using System;
using System.Collections.Generic;

namespace SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listNum = new List<int>();
            int numberOne = int.Parse(Console.ReadLine());
            listNum.Add(numberOne);
            int numberTwo = int.Parse(Console.ReadLine());
            listNum.Add(numberTwo);
            int numberThree = int.Parse(Console.ReadLine());
            listNum.Add(numberThree);
            listNum.Sort();
            listNum.Reverse();
            listNum.ForEach(Console.WriteLine);
        }
    }
}
