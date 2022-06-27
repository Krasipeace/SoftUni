using System;

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
            
        }
    }
}
