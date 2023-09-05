namespace _05.ReverseNumbersWithaStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write numbers(1 2 3 4 5 etc.):");
            int[] input = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            Stack<int> stack = new();
            foreach (int num in input)
            {
                stack.Push(num);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}