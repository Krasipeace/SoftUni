namespace Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape[] shapes = new IShape[]
            {
                new Circle(),
                new Rectangle(),
                new Square(),
            };

            GraphicEditor graphicEditor = new GraphicEditor();

            foreach (IShape shape in shapes)
            {
                graphicEditor.DrawShape(shape);
            }
        }
    }
}
