using System;

namespace zad16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //16.Програма, която по дадено число N отпечатва числата от 1 до N, разбъркани в случаен ред.

            Console.Write("Enter number [1..N]: ");
            int numberN = int.Parse(Console.ReadLine());
            int[] arrayN = new int[numberN];
           
            for (int i = 0; i < arrayN.Length; i++)
            {
                arrayN[i] = i;
            }
            Random rnd = new Random();

            foreach (int i in arrayN)
            {
                int randomNumber = rnd.Next(1, numberN);
                int tempN = arrayN[i];
                arrayN[i] = arrayN[randomNumber];
                arrayN[randomNumber] = tempN;
            }

            foreach (int i in arrayN)
            {
                Console.WriteLine(arrayN[i]);
            }
            //unfinished
        }
    }
}
