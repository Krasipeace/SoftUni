using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            int[] swapIndex = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            int firstBox = swapIndex[0];
            int secondBox = swapIndex[1];

            Swap(boxes, firstBox, secondBox);

            foreach (var item in boxes)
            {
                Console.WriteLine(item);
            }
        }

        public static void Swap<T>(List<Box<T>> boxes, int firstBox, int secondBox)
        {
            Box<T> swapTemp = boxes[firstBox];
            boxes[firstBox] = boxes[secondBox];
            boxes[secondBox] = swapTemp;
        }
    }
}
