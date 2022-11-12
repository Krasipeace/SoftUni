namespace DetailPrinter
{
    public class Printer : IPrinting
    {
        public void Printing(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
