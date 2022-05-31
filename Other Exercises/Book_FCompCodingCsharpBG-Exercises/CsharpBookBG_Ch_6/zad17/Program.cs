using System;

namespace zad17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //17.Програма, която за дадени две числа, намира най-големия им общ делител.

            Console.Write("Enter first number: ");
            int numOne = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int numTwo = int.Parse(Console.ReadLine());

            while (numOne != 0 && numTwo != 0)
            {
                if (numOne > numTwo)
                {
                    numOne %= numTwo;
                }
                else
                {
                    numTwo %= numOne;
                }
            }

            if (numOne == 0)
            {
                Console.WriteLine(numTwo);
            }
            else
            {
                Console.WriteLine(numOne);
            }

        }
    }
}
