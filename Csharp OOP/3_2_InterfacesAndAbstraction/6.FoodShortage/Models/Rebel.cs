namespace BorderControl.Models
{
    using Interfaces;

    public class Rebel : IBuyer
    {
        private const int REBEL_BUYER = 5;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }
        public void BuyFood()
        {
            Food += REBEL_BUYER;
        }
    }

}
