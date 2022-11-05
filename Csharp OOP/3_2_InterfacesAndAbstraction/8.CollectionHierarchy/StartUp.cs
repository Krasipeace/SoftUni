namespace CollectionHierarchy
{
    using CollectionHierarchy.Core;
    using CollectionHierarchy.Core.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}