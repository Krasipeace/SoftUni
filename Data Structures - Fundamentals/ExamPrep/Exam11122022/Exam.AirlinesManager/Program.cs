using Exam.DeliveriesManager;

using System;

namespace Exam.AirlinesManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tower");
            var airline = new Airline("1", "airline", 1000);
            var flight = new Flight("1", "2", "3", "4", true);
        }
    }
}
