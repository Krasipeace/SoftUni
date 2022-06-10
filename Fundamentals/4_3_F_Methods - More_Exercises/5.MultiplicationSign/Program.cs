using System;

namespace _5.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            Result(numberOne, numberTwo, numberThree);
        }

        static bool CheckZero(int numberOne, int numberTwo, int numberThree)
        {
            if (numberOne == 0 || numberTwo == 0 || numberThree == 0)
            {
                return true;
            }
            return false;
        }

        static bool CheckNegative(int numberOne, int numberTwo, int numberThree)
        {
            int[] numbers = new int[] { numberOne, numberTwo, numberThree };
            int counter = 0;

            for (int i = 0; i < 3; i++)
            {
                if (numbers[i] < 0)
                {
                    counter++;
                }
            }

            if (counter % 2 == 0)
            {
                return false;
            }
            return true;

        }

        static void Result(int numberOne, int numberTwo, int numberThree)
        {
            if (CheckZero(numberOne, numberTwo, numberThree))
            {
                Console.WriteLine("zero");
            }
            else if (CheckNegative(numberOne, numberTwo, numberThree))
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }

    }
}
