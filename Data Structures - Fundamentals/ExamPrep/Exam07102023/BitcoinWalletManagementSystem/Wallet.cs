namespace BitcoinWalletManagementSystem
{
    using System.Collections.Generic;

    public class Wallet
    {
        public Wallet()
        {
            this.Id = Id;
            this.UserId = UserId;
            this.User = User;
            this.Balance = Balance;
            this.Transactions = new List<Transaction>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public long Balance { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}