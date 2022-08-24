using System;
using System.Collections.Generic;

namespace _7._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string input = Console.ReadLine();
            while (true)
            { 
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(", ");
                string command = tokens[0];
                string plateNumber = tokens[1];

                switch(command)
                {
                    case "IN": 
                        parkingLot.Add(plateNumber);
                        break;
                    case "OUT":
                        parkingLot.Remove(plateNumber);
                        break;
                }

                input = Console.ReadLine();
            }

            if (parkingLot.Count > 0)
            {
                foreach (var item in parkingLot)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
