using System;
using System.Linq;

namespace _4.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
            Lake<int> lake = new Lake<int>(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
