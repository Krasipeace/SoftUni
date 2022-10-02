using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int left = int.Parse(Console.ReadLine());
            int right = int.Parse(Console.ReadLine());

            EqualityScale<int> equality = new EqualityScale<int>(left, right);

            Console.WriteLine(equality.AreEqual());
        }
    }
}
