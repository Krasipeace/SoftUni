using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int givenIndex = int.Parse(command[1]);
                    array = ExchangeArray(array, givenIndex);
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    FindMinOrMax(array, command[0], command[1]);
                }
                else
                {
                    FindNumbers(array, command[0], command[1]);
                }

                command = Console.ReadLine().Split();
            }
        }

        private static int[] ExchangeArray(int[] array, int givenIndex)
        {
            
        }

        private static void FindMinOrMax(int[] array, string v1, string v2)
        {
            
        }

        private static void FindNumbers(int[] array, string v1, string v2)
        {
            
        }
    }
}
