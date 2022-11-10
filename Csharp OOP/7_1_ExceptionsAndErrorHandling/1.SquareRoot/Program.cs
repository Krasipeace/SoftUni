using System;

namespace _1.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                int number = int.Parse(Console.ReadLine());
                int x = (int)Math.Sqrt(number);

                if (x >= 0)
                {
                    Console.WriteLine(x);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number."); 
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
