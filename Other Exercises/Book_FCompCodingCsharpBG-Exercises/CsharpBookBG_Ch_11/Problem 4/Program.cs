using System; //time elapsed since start of PC

namespace Problem_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double milliseconds = (double)Environment.TickCount64;
            double seconds = milliseconds / 1000;
            double minutes = seconds / 60;
            double hours = minutes / 60;
            double day = hours / 24;

            Console.WriteLine($"Time elapsed since start of PC: {day:f2} days = {hours:f2} hours = {minutes:f2} minutes = {seconds:f2} seconds = {milliseconds:f2} ms.");
        }
    }
}
