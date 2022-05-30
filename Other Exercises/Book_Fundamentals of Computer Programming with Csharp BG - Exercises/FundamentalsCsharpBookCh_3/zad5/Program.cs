using System;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //5.Напишете израз, който изчислява площта на трапец по дадени a, b и h.
            Console.WriteLine("Find the area of trapezoid by entering its sides(a,b) and height (h)");

            Console.Write("Enter side a: ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("Enter side b: ");
            float b = float.Parse(Console.ReadLine());
            Console.Write("Enter height h: ");
            float h = float.Parse(Console.ReadLine());

            float area = (a + b) * h / 2;

            Console.WriteLine($"Trapezoid area: {area:f2}");

        }
    }
}
