using System;

namespace zad9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //.Напишете програма, която проверява дали дадена точка О (x, y) е вътре в окръжността К ((0,0), 5) и едновременно с това извън право­ъгълника ((-1, 1), (5, 5).
            //Пояснение: правоъгълникът е зададен чрез координатите на горния си ляв и долния си десен ъгъл.

            Console.WriteLine("The Program checks if your point O (x,y) coordinates are in the area of a circle K ((0,0), 5 and are in the coordinates of Rectangle");
            int radius = 5;
            Console.Write("Enter coordinate X: ");
            double coordX = double.Parse(Console.ReadLine());
            Console.Write("Enter coordinate Y: ");
            double coordY = double.Parse(Console.ReadLine());
            double coordPoint = (coordX * coordX) + (coordY * coordY);

            bool checkPoint = (coordX <= (radius * radius));
            bool checkPointR = (((coordX > -1) && (coordY < 1)) && ((coordX < 5) && (coordY < 5)));

            Console.WriteLine("Your point is in the circle: " + checkPoint);
            Console.WriteLine("Your point is in the Rectangle: " + checkPointR);
        }
    }
}
