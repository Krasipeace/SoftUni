using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDoubles
{
    public class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            List<double> boxes = new List<double>();
            for (int i = 0; i < inputs; i++)
            {
                boxes.Add(double.Parse(Console.ReadLine()));
            }
            double comparison = double.Parse(Console.ReadLine());

            Console.WriteLine(GenericCount(boxes, comparison));
        }

        public static double GenericCount<T>(List<T> boxes, T comparison) where T : IComparable<T>
        {
            return boxes.Count(x => x.CompareTo(comparison) > 0);
        }
    }
}
