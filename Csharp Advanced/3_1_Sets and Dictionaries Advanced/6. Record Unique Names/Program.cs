using System;
using System.Collections.Generic;

namespace _6._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                string addName = Console.ReadLine();
                names.Add(addName);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
