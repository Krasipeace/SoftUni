using System;

namespace _5.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputOne = int.Parse(Console.ReadLine());
            int inputTwo = int.Parse(Console.ReadLine());
            int inputThree = int.Parse(Console.ReadLine());

            int addResult = AddOneAndTwo(inputOne, inputTwo);
            int finalResult = SubstractThree(addResult, inputThree);

            AddOneAndTwo(inputOne, inputTwo);

            SubstractThree(addResult, inputThree);

            PrintResult(finalResult);

        }

        private static void PrintResult(int result) => Console.WriteLine(result);

        private static int SubstractThree(int addResult, int inputThree)
        {
            return addResult - inputThree;
        }

        private static int AddOneAndTwo(int inputOne, int inputTwo)
        {
            return inputOne + inputTwo;
        }
    }
}
