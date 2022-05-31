using System;

namespace zad10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //10.Напишете програма, която прочита едно цяло число N от конзолата.
            //След това прочита още N на брой числа от конзолата и отпечатва тяхната сума.
            Console.WriteLine("Enter N numbers and sums them up... Dont enter big numbers or enjoy forever entering all those N numbers!");
            Console.Write("Enter number N: ");
            int numberN = int.Parse(Console.ReadLine());
            int result = 0;
            for (int counter = 0; counter < numberN; counter++)
            {
                result += numberN;
                
                //Console.Write("Enter next N-number: ");
               // int numberX = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Sum of all N-numbers is: " + result);


        }
    }
}
