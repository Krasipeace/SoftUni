using System; //random numbers [100..200]

namespace Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            Console.Write($"Random number generator [100..200]: ");

            for (int i = 0; i < 10; i++)
            {
                int output = random.Next(100, 201);
                Console.Write($"{output} ");
            }
            Console.WriteLine();
        }
    }
}
