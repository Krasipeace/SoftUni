using System;

namespace OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double result = 0;

            if (operation == '+' || operation == '-' || operation == '*')
            {
                string evenOrOdd = "odd";
                if (operation == '+')
                {
                    result = number1 + number2;
                }
                else if (operation == '-')
                {
                    result = (number1 - number2);
                }
                else
                {
                    result = number1 * number2;
                }
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                Console.WriteLine($"{number1} {operation} {number2} = {result} - {evenOrOdd}");
            }
            else
            {
                if (number2 == 0)
                {
                    Console.WriteLine($"Cannot divide {number1} by zero");
                }
                else
                {
                    if (operation == '/')
                    {
                        result = 1.0 * number1 / number2;
                        Console.WriteLine($"{number1} {operation} {number2} = {result:f2}");
                    }
                    else
                    {
                        result = number1 % number2;
                        Console.WriteLine($"{number1} {operation} {number2} = {result}");
                    }
                }
            }
        }
    }
}
