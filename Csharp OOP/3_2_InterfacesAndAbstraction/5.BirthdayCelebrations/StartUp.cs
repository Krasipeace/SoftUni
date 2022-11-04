namespace BorderControl
{
    using BorderControl.Core;
    using BorderControl.Core.Interfaces;
    
    public class StartUp
    {       
        static void Main()
        {
            IEngine engine = new BirthdayCheck();

            engine.RunEngine();
        }       
    }
}