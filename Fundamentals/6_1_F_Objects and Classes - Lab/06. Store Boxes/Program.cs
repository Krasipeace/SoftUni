using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    public class Box
    {
        public string BoxSerialNumber { get; set; }
        public decimal PriceItem { get; set; }
        public string Name  { get; set; }
        public int BoxQuantity { get; set; }
        public decimal BoxPrice { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split(" ");
                string serialNumberBox = tokens[0];
                string itemName = tokens[1];
                int boxQuantity = int.Parse(tokens[2]);
                decimal itemPrice = decimal.Parse(tokens[3]);

                Box Box = new Box()
                {
                    BoxSerialNumber = serialNumberBox,
                    Name = itemName,
                    PriceItem = itemPrice,                   
                    BoxQuantity = boxQuantity,
                    BoxPrice = boxQuantity * itemPrice,
                };
                command = Console.ReadLine();

                boxes.Add(Box);
            }

            foreach (Box eachBox in boxes.OrderByDescending(currentBox => currentBox.BoxPrice))
            {
                Console.WriteLine(eachBox.BoxSerialNumber);
                Console.WriteLine($"-- {eachBox.Name} - ${eachBox.PriceItem:f2}: {eachBox.BoxQuantity}");
                Console.WriteLine($"-- ${eachBox.BoxPrice:f2}");
            }
        }
    }
}
