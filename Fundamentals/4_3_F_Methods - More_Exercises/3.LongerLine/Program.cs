using System;

namespace _3.LongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            //инициализация на всяка линия
            double lenghtLineOne = CheckLineLenght(x1, y1, x2, y2);
            double lenghtLineTwo = CheckLineLenght(x3, y3, x4, y4);

            //сравнение на дължината на линията
            if (lenghtLineOne >= lenghtLineTwo)                        
            {
                bool isClosest = CloseToCenterPoint(x1, y1, x2, y2);

                if (isClosest)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }

                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");

                }

            }

            else
            {
                bool isClosest = CloseToCenterPoint(x3, y3, x4, y4);
                if (isClosest)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }

                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }

        }

        static double CheckLineLenght(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));  //дължина
        }

        static bool CloseToCenterPoint(double x1, double y1, double x2, double y2)
        {
            double lineOne = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));  //хипотенуза
            double lineTwo = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));

            if (lineOne <= lineTwo)
            {
                return true;
            }

            return false;
        }
    }
}
