namespace _6._Quick_Sort
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            QuickSort<int>(array);

            Console.WriteLine(string.Join(" ", array));
        }

        public static void QuickSort<T>(T[] array) where T : IComparable<T>
        {
            Shuffle(array);

            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start >= end)
            {
                return;
            }

            int p = Partition(array, start, end);

            Sort(array, start, p - 1);

            Sort(array, p + 1, end);
        }

        private static void Shuffle<T>(T[] array) where T : IComparable<T>
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int rnd = i + random.Next(0, array.Length - i);
                Swap(array, i, rnd);
            }
        }

        private static int Partition<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start >= end)
            {
                return start;
            }

            int low = start;
            int high = end + 1;

            while (true)
            {
                while (array[++low].CompareTo(array[start]) < 0)
                {
                    if (low == end) break;
                }

                while (array[start].CompareTo(array[--high]) < 0)
                {
                    if (high == start) break;
                }

                if (low >= high)
                {
                    break;
                }

                Swap(array, low, high);
            }

            Swap(array, start, high);

            return high;
        }

        static void Swap<T>(T[] array, int low, int high)
        {
            (array[high], array[low]) = (array[low], array[high]);
        }
    }
}
