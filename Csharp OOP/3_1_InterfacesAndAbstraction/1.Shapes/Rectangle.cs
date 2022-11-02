﻿using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width
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
        public int Height
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

        public void Draw()
        {
            DrawLine(Width, '*', '*');

            for (int i = 1; i < Height; ++i)
            {
                DrawLine(Width, '*', ' ');
            }

            DrawLine(Width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
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
