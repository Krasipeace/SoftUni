using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int WREATH_FLOWERS = 15;
            const int WREATH_NEED = 5;
            const int DECREASE_LILLIES = 2;

            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(r => int.Parse(r)).ToArray());
            Stack<int> lillies = new Stack<int>(Console.ReadLine().Split(", ").Select(l => int.Parse(l)).ToArray());

            int leftFlowers = 0;
            int wreathCounter = 0;

            while (roses.Count > 0 && lillies.Count > 0)
            {
                int lilliesCount = lillies.Peek();
                int sumFlowers = roses.Peek() + lilliesCount;

                if (sumFlowers == WREATH_FLOWERS)
                {
                    wreathCounter++;
                    roses.Dequeue();
                    lillies.Pop();
                }
                else if (sumFlowers > WREATH_FLOWERS)
                {              
                    lillies.Pop();
                    lillies.Push(lilliesCount - DECREASE_LILLIES);
                }
                else if (sumFlowers < WREATH_FLOWERS)
                {                  
                    leftFlowers += roses.Dequeue() + lillies.Pop();
                }
            }

            if (leftFlowers >= WREATH_FLOWERS)
            {
                double moreWreaths = Math.Floor(1.0 * leftFlowers / WREATH_FLOWERS);
                if (moreWreaths >= 1)
                {
                    wreathCounter += (int)moreWreaths;
                }
            }

            if (wreathCounter >= WREATH_NEED)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCounter} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {Math.Abs(WREATH_NEED - wreathCounter)} wreaths more!");
            }
        }
    }
}
