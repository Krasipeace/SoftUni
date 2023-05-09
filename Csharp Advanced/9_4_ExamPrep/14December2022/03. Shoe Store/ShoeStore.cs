namespace ShoeStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public int Count => Shoes.Count;

        public string Name { get; set; }

        public int StorageCapacity { get; set; }

        public List<Shoe> Shoes { get; set; }

        public string AddShoe(Shoe shoe)
        {
            if (Count >= StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            Shoes.Add(shoe);

            return $"Successfully added {shoe.Type.ToLower()} {shoe.Material.ToLower()} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            var shoesToRemove = Shoes
                .Where(s => s.Material.ToLower() == material.ToLower())
                .ToList();

            var shoes = Shoes.RemoveAll(s => s.Material.ToLower() == material.ToLower());

            return shoesToRemove.Count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            var shoesByType = Shoes
                .Where(s => s.Type.ToLower() == type.ToLower())
                .ToList();

            return shoesByType;
        }

        public Shoe GetShoeBySize(double size)
            => Shoes.FirstOrDefault(s => s.Size == size);

        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();

            var shoes = Shoes
                .Where(s => s.Size == size && s.Type.ToLower() == type.ToLower())
                .ToList();

            if (shoes.Count == 0)
            {
                return $"No matches found!";
            }

            sb
                .AppendLine($"Stock list for size {size} - {type} shoes:")
                .AppendLine(string.Join(Environment.NewLine, shoes));
            
            return sb.ToString().TrimEnd();
        }
    }
}
