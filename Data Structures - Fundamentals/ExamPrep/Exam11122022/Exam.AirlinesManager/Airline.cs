namespace Exam.DeliveriesManager
{
    public class Airline
    {
        public Airline(string id, string name, double rating)
        {
            Id = id;
            Name = name;
            Rating = rating;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }
    }
}
