namespace MaxPossibleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            string maxNumber = GetMaxPossibleNumber(input);

            Console.WriteLine(maxNumber);
        }

        static string GetMaxPossibleNumber(List<int> numbers)
        {
            List<string> numbersAsStrings = numbers.Select(n => n.ToString().TrimStart('0')).ToList();

            Comparison<string> comparison = (s1, s2) => (s2 + s1).CompareTo(s1 + s2);

            numbersAsStrings.Sort(comparison);

            string maxNumber = string.Join("", numbersAsStrings);

            return maxNumber;
        }
    }
}