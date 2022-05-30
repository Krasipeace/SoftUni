using System;

namespace zad6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //6. Напишете програма, която за подадени от потребителя дължина и височина на право­ъгълник, пресмята и отпечатва на конзолата неговия периметър и лице.

            Console.WriteLine("Enter sideA,sideB and height of a Rectangle");

            Console.Write("Enter 1st side: ");
            float sideA = float.Parse(Console.ReadLine());
            Console.Write("Enter 2nd side: ");
            float sideB = float.Parse(Console.ReadLine());
            Console.Write("Enter Height of a Rectangle: ");
            float height = float.Parse(Console.ReadLine());

            float area = sideA * sideB;
            float perimeterR = (sideA * sideB) * 2;

            Console.WriteLine("Area of Rectangle is: " + area);
            Console.WriteLine("Perimeter of Rectanfle is: " + perimeterR);
        }
    }
}
