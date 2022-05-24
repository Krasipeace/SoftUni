using System;

namespace AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();  //четем стринг с името на фигурата square , rectangle , circle , triangle
            double area = 0;
            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = r * r * Math.PI;
                
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                area = a * ha / 2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}
