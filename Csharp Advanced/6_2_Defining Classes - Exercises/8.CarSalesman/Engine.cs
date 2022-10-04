using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, int power, string displacement, string efficiency)
            : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public static void PrintEngine(Engine engine)
        {
            Console.WriteLine($"  {engine.Model}:");
            Console.WriteLine($"   Power: {engine.Power}");
            Console.WriteLine($"   Displacement: {engine.Displacement}");
            Console.WriteLine($"   Efficiency: {engine.Efficiency}");
        }
    }
}
