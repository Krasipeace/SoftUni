using System;

namespace zad8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //8.Напишете програма, която проверява дали дадена точка О (x, y) е вътре в окръжността К ((0,0), 5).
            //Пояснение: точката (0,0) е център на окръжността, а радиусът й е 5.(аз си я усложних с въвеждане на произволен радиус)

            Console.WriteLine("The Program checks if your point O (x,y) coordinates are in the area of a circle K ((0,0), radius");
            Console.Write("Enter radius of a Circle: ");

            int radius = int.Parse(Console.ReadLine());
            Console.Write("Enter coordinate X: ");
            double coordX = double.Parse(Console.ReadLine());
            Console.Write("Enter coordinate Y: ");

            double coordY = double.Parse(Console.ReadLine());
            double coordPoint = (coordX * coordX) + (coordY * coordY);
            bool checkPoint = (coordX <= (radius * radius));

            Console.WriteLine("Your point is in the circle: " + checkPoint);
        }
    }
}
