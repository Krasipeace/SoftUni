namespace BitcoinWalletManagementSystem
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Count { get; set; }

        public long Balance { get; set; }

        public User()
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
        }
    }
}