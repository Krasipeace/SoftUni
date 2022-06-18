using System;
using System.Collections.Generic;

namespace _3._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guestLimit = int.Parse(Console.ReadLine());
            List<string> checkList = new List<string>();

            for (int i = 0; i < guestLimit; i++)
            {
                var command = Console.ReadLine().Split();   
                string currentName = command[0];

                if (checkList.Contains(currentName) && command[2] == "going!")
                {
                    Console.WriteLine($"{currentName} is already in the list!");
                }
                else if (checkList.Contains(currentName) && command[2] == "not")
                {
                    checkList.Remove(currentName);
                }
                else if (!checkList.Contains(currentName) && command[2] == "not")
                {
                    Console.WriteLine($"{currentName} is not in the list!");
                }
                else
                {
                    checkList.Add(currentName);
                }
            }

            foreach (var currName in checkList)
            {
                Console.WriteLine(currName);
            }
        }
    }
}
