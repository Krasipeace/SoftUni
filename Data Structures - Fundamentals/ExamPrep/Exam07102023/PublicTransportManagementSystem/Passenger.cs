namespace PublicTransportManagementSystem
{
    public class Passenger
    {
        public Passenger()
        {
            this.Id = Id;
            this.Name = Name;
            this.Bus = Bus;
        }

        public string Id { get; set; }
    
        public string Name { get; set; }

        public Bus Bus { get; set; }
    }
}