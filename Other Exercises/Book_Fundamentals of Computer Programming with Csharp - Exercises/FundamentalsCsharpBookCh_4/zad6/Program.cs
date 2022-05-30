using System;

namespace zad6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //6.Напишете програма, която чете две числа от конзолата и отпечатва по-голямото от тях. Решете задачата без да използвате условни конструкции.
            Console.WriteLine("Enter two numbers and find out which one is bigger");

            Console.Write("Enter first number: ");
            int numberOne = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int numberTwo = int.Parse(Console.ReadLine());

            Console.WriteLine("The bigger number is: " + Math.Max(numberOne, numberTwo));

            // Console.WriteLine("The smaller number is: " + Math.Min(numberOne, numberTwo));
        }
    }
}
