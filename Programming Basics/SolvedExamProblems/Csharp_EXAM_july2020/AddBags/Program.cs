using System;

namespace AddBags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baggage = double.Parse(Console.ReadLine());
            int baggageWeight = int.Parse(Console.ReadLine());
            int daysToJourney = int.Parse(Console.ReadLine());
            int baggageBags = int.Parse(Console.ReadLine());               

            if (baggageWeight < 10)
            {
                baggage = baggage - baggage * 0.80;
            }
            else if (baggageWeight <= 20)
            {
                baggage = baggage - baggage * 0.50;
            }
            if (daysToJourney < 7)
            {
                baggage = baggage + baggage * 0.40;
            }
            else if (daysToJourney <= 30)
            {
                baggage = baggage + baggage * 0.15;
            }
            else
            {
                baggage = baggage + baggage * 0.10;
            }

            double priceBaggage = baggage * baggageBags;

            Console.WriteLine($"The total price of bags is: {priceBaggage:f2} lv.");
        }
    }
}
