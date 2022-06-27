using System;
using System.Collections.Generic;

namespace _06._Store_Boxes
{
    class Item
    {
        public string Name { get; set; }
        public decimal PriceItem { get; set; }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> students = new List<Box>();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                string serialNumber = tokens[0];
                string itemName = tokens[1];
                int boxQuantity = int.Parse(tokens[2]);
                decimal itemPrice = decimal.Parse(tokens[3]);
            }
        }
    }
}
