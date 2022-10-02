using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            List<string> boxes = new List<string>();
            for (int i = 0; i < inputs; i++)
            {
                boxes.Add(Console.ReadLine());
            }
            string comparison = Console.ReadLine();

            Console.WriteLine(GenericCount(boxes, comparison));
        }

        public static int GenericCount<T>(List<T> boxes, T comparison) where T : IComparable<T>
        {
            return boxes.Count(x => x.CompareTo(comparison) > 0);
        }
    }
}
