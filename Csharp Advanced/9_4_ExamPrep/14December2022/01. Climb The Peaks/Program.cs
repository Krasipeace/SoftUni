namespace _01._Climb_The_Peaks
{
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<string, int> peaks = new()
        {
            { "Vihren", 80 },
            { "Kutelo", 90 },
            { "Banski Suhodol", 100 },
            { "Polezhan", 60 },
            { "Kamenitza", 70 }
        };

        static void Main(string[] args)
        {
            Stack<int> foodPortions = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Queue<int> stamina = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Queue<string> conqueredPeaks = new();

            while (foodPortions.Count != 0 && stamina.Count != 0)
            {
                int sum = foodPortions.Pop() + stamina.Dequeue();

                KeyValuePair<string, int> currentPeak = peaks.FirstOrDefault();

                if (sum < currentPeak.Value)
                {
                    continue;
                }

                conqueredPeaks.Enqueue(currentPeak.Key);
                peaks.Remove(currentPeak.Key);

                if (peaks.Count == 0)
                {
                    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
                    break;
                }
            }

            if (peaks.Count != 0)
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Count != 0)
            {
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
            }
        }
    }
}
