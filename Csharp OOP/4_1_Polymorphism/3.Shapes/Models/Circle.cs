namespace Shapes.Models
{
    using System;

    using Shapes.Models.Interfaces;
    public class Circle : Shape, IDrawable
    {
        private double radius;
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius
        {
            get
            {
                return radius;
            }
            private set
            {
                radius = value;
            }
        }

        public override double CalculatePerimeter() => 2 * Math.PI * radius;
        public override double CalculateArea() => Math.PI * Math.Pow(radius, 2);
        public override string Draw() => base.Draw() + GetType().Name;

        public void Drawing()
        {
            double rIn = Radius - 0.4;
            double rOut = Radius + 0.4;
            for (double y = Radius; y >= -Radius; --y)
            {
                for (double x = -Radius; x < rOut; x += 0.5)
                {
                    double value = (x * x) + (y * y);

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
