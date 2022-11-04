namespace Shapes.Models
{
    using System;

    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                height = value;
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                width = value;
            }
        }

        public override double CalculatePerimeter() => (Height + Width) * 2;
        public override double CalculateArea() => Height * Width;
        public override string Draw() => base.Draw() + GetType().Name;

        public void Drawing()
        {
            DrawLine(Width, '*', '*');

            for (int i = 1; i < Height; ++i)
            {
                DrawLine(Width, '*', ' ');
            }

            DrawLine(Width, '*', '*');
        }
        private void DrawLine(double width, char end, char mid)
        {
            Console.Write(end);

            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);
            }

            Console.WriteLine(end);
        }
    }
}
