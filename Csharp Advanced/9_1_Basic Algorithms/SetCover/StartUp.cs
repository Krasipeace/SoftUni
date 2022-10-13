namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp          //https://en.wikipedia.org/wiki/Set_cover_problem
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int numberOfSets = int.Parse(Console.ReadLine());
            int[][] sets = new int[numberOfSets][];

            for (int row = 0; row < sets.Length; row++)
            {
                int[] rowsValue = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                sets[row] = new int[rowsValue.Length];

                for (int col = 0; col < sets[row].Length; col++)
                {
                    sets[row][col] = rowsValue[col];
                }
            }

            List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var item in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", item)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> resultSet = new List<int[]>();

            HashSet<int> universeSet = new HashSet<int>(universe);
            HashSet<int[]> selectedSet = new HashSet<int[]>(sets);

            while (universeSet.Count > 0)
            {
                int[] currentSet = selectedSet.OrderByDescending(s => s.Count(e => universeSet.Contains(e))).First();

                resultSet.Add(currentSet);
                selectedSet.Remove(currentSet);

                foreach (int number in currentSet)
                {
                    universeSet.Remove(number);
                }
            }

            return resultSet;           
        }
    }
}
