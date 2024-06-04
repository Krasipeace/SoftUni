namespace BorderControl.Models
{
    using Interfaces;
    public class Citizen : IIdentify, IBirthdate, IBuyer
    {
        private const int CITIZEN_BUYER = 10;
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }
        public void BuyFood()
        {
            Food += CITIZEN_BUYER;
        }
    }
}
