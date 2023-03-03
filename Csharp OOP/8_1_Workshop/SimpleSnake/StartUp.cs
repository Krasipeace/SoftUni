namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.Core.Contracts;
    using SimpleSnake.GameObjects;
    using SimpleSnake.Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall (60, 20);

            IEngine engine = new Engine(wall);
            engine.Run();
        }
    }
}
