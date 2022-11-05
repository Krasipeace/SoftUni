namespace ExplicitInterfaces
{
    using ExplicitInterfaces.Core;
    using ExplicitInterfaces.Core.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
