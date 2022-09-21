using System;
using System.Collections.Generic;

namespace _1._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < inputs; i++)
            {
                string uniqueName = Console.ReadLine();
                names.Add(uniqueName);
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
