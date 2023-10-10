using System;
using System.Collections.Generic;
using System.Linq;
//Performance version
namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private readonly Dictionary<string, User> users = new Dictionary<string, User>();
        private readonly Dictionary<string, Wallet> wallets = new Dictionary<string, Wallet>();

        public void CreateUser(User user)
        {
            if (ContainsUser(user))
            {
                throw new ArgumentException();
            }

            this.users.Add(user.Id, user);
        }

        public void CreateWallet(Wallet wallet)
        {
            if (ContainsWallet(wallet))
            {
                throw new ArgumentException();
            }

            this.users[wallet.UserId].Balance += wallet.Balance;
            this.wallets.Add(wallet.Id, wallet);
        }

        public bool ContainsUser(User user)
            => this.users.ContainsKey(user.Id);

        public bool ContainsWallet(Wallet wallet)
            => this.wallets.ContainsKey(wallet.Id);

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
            => this.wallets.Values
                .Where(w => w.UserId == userId);

        public void PerformTransaction(Transaction transaction)
        {
            var sender = this.wallets[transaction.SenderWalletId];
            var receiver = this.wallets[transaction.ReceiverWalletId];

            if (!this.wallets.ContainsKey(transaction.SenderWalletId) ||
                !this.wallets.ContainsKey(transaction.ReceiverWalletId) ||
                this.wallets[transaction.SenderWalletId].Balance < transaction.Amount)
            {
                throw new ArgumentException();
            }

            sender.Transactions.Add(transaction);
            receiver.Transactions.Add(transaction);
            sender.Balance -= transaction.Amount;
            receiver.Balance += transaction.Amount;
            this.users[sender.UserId].Count++;
            this.users[receiver.UserId].Count++;
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
            => this.wallets.Values
                .First(w => w.UserId == userId).Transactions;

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()   
            => this.wallets.Values
                .OrderByDescending(w => w.Balance);

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
            => this.users.Values
                .OrderByDescending(u => u.Balance);    

        public IEnumerable<User> GetUsersByTransactionCount()
            => this.users.Values
                .OrderByDescending(u => u.Count);
    }
}