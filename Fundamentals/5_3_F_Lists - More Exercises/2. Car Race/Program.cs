using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Car_Race
{
    internal class Program
    {
//Напишете програма за изчисляване на победителя в автомобилно състезание.
//Ще получите масив от числа. Всеки елемент от масива представлява времето,
//необходимо за преминаване през тази стъпка (индекса). Ще има две коли.
//Едната започва от лявата страна, а другата започва от дясната.
//Средният индекс на масива е финалната линия. Броят на елементите в масива винаги ще бъде нечетен.
//Изчислете общото време за всеки състезател да стигне до финала, който е средата на масива, и отпечатайте победителя с общото му време (състезателят с по-малко време).
//Ако имате нула в масива, трябва да намалите времето на състезателя, който я е достигнал с 20% (от текущото му време).

        static void Main(string[] args)
        {
            List<int> raceTrack = Console.ReadLine().Split().Select(int.Parse).ToList();
            double leftRacer = 0;
            double rightRacer = 0;

            leftRacer = LeftRacer(raceTrack, leftRacer);
            rightRacer = RightRacer(raceTrack, rightRacer);

            CheckWinner(leftRacer, rightRacer);
        }

        private static void CheckWinner(double leftRacer, double rightRacer)
        {
            if (leftRacer < rightRacer)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacer}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightRacer}");
            }
        }

        private static double RightRacer(List<int> raceTrack, double rightRacer)
        {
            for (int timeIndex = raceTrack.Count - 1; timeIndex > raceTrack.Count / 2; timeIndex--)
            {
                rightRacer += raceTrack[timeIndex];

                if (raceTrack[timeIndex] == 0)
                {
                    rightRacer *= 0.8;
                }
            }
            return rightRacer;
        }

        private static double LeftRacer(List<int> raceTrack, double leftRacer)
        {
            for (int timeIndex = 0; timeIndex < raceTrack.Count / 2; timeIndex++)
            {
                leftRacer += raceTrack[timeIndex];

                if (raceTrack[timeIndex] == 0)
                {
                    leftRacer *= 0.8;
                }
            }
            return leftRacer;
        }
    }
}
