using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus transactionStatus;
        private string from;
        private string to;
        private double amount;


        public Transaction(int id, TransactionStatus ts, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = ts;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id should be positive!");
                }
                this.id = value;
            }
        }
        public TransactionStatus Status
        {
            get
            {
                return this.transactionStatus;
            }
            set
            {
                this.transactionStatus = value;
            }
        }
        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender name should not be whitespace or empty!");
                }
                this.from = value;
            }
        }
        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Reciever name should not be whitespace or empty!");
                }
                this.to = value;
            }
        }
        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount value must be positive!");
                }
                this.amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            if (this.Id.CompareTo(other.Id) != 0)
            {
                return this.Id.CompareTo(other.Id);
            }
            else if (this.Status != other.Status || this.From != other.From || this.To != other.To || this.Amount != other.Amount)
            {
                throw new ArgumentException();
            }
            return 0;
        }
    }
}
