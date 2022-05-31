using System;

namespace zad11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //11.Напишете програма, която прочита цяло число n от конзолата и отпечатва на конзолата всички числа в интервала [1…n], всяко на отделен ред.
            Console.WriteLine("Print all number in the interval [1..n] on new line");
            Console.Write("Enter number number N = ");

            int numberN = int.Parse(Console.ReadLine());
            int num = 0;
            while (num < numberN)
            {
                num++;
                Console.WriteLine(num);
            }
            //Console.WriteLine(" = " + sum);
        }
    }
}
