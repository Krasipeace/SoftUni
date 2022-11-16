namespace Stealer
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzedAccessModifiers("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
