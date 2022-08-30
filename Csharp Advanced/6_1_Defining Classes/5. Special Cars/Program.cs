using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> enginesList = new List<Engine>();
            List<Tire[]> tiresList = new List<Tire[]>();

            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                string[] tiresInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int tireYear = int.Parse(tiresInfo[0]);
                double tirePressure = double.Parse(tiresInfo[1]);


            }
        }
    }
}
