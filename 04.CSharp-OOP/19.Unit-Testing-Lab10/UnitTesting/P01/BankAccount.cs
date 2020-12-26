using System;
using System.Collections.Generic;
using System.Text;

namespace P01
{
    public class BankAccount
    {
        private decimal balance;

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance can not be negative");
                }

                this.balance = value;
            }
        }

        public BankAccount(decimal balance)
        {
            this.Balance = balance;
        }

        public void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be positive number");
            }

            this.Balance += sum;
        }

        public decimal Withdraw(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be positive number");
            }

            this.Balance -= sum;

            return this.Balance;
        }
    }
}
