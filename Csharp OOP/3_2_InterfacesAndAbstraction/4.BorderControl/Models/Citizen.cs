namespace BorderControl.Models
{
    using Interfaces;

    public class Citizen : IIdentify
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}

