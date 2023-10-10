using System;
using System.Collections.Generic;

namespace BitcoinWalletManagementSystem
{
    public class Transaction
    {
        public Transaction()
        {
            this.Id = Id;
            this.SenderWalletId = SenderWalletId;
            this.ReceiverWalletId = ReceiverWalletId;
            this.Amount = Amount;
            this.Timestamp = Timestamp;
        }

        public string Id { get; set; }

        public string SenderWalletId { get; set; }

        public string ReceiverWalletId { get; set; }

        public long Amount { get; set; }

        public DateTime Timestamp { get; set; }
    }
}

