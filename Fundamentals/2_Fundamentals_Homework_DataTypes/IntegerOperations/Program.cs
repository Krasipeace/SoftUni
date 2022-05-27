using System;

namespace IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            int numberFour = int.Parse(Console.ReadLine());

            int operationAdd = numberOne + numberTwo;
            int operationDivide = operationAdd / numberThree;
            int operationMultiply = operationDivide * numberFour;

            Console.WriteLine(operationMultiply);
        }
    }
}
