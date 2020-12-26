using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> byId;
        private Dictionary<TransactionStatus, HashSet<ITransaction>> byStatus;


        public Chainblock()
        {
            this.byId = new Dictionary<int, ITransaction>();
            this.byStatus = new Dictionary<TransactionStatus, HashSet<ITransaction>>();
        }

        public int Count => this.byId.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException("Transaction already exists!");
            }
            this.byId[tx.Id] = tx;

            if (!this.byStatus.ContainsKey(tx.Status))
            {
                this.byStatus[tx.Status] = new HashSet<ITransaction>();
            }
            this.byStatus[tx.Status].Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.byId.ContainsKey(id))
            {
                throw new ArgumentException("There is no transaction with given id present in the collection!");
            }

            ITransaction tr = this.byId[id];
            
            this.byStatus[tr.Status].Remove(tr);
            tr.Status = newStatus;

            if (!this.byStatus.ContainsKey(newStatus))
            {
                this.byStatus[newStatus] = new HashSet<ITransaction>();
            }

            this.byStatus[newStatus].Add(tr);
        }

        public bool Contains(ITransaction tx)
        {
            return this.byId.Values.Contains(tx);
        }

        public bool Contains(int id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("Invalid Id!");
            }
            return this.byId.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.byId
                .Values
                .Where(t => t.Amount >= lo)
                .Where(t => t.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.byId.Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!this.byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are no transactions with given status present in the collection!");
            }

            List<string> recievers = this.byStatus[status]
                .OrderByDescending(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            if (recievers.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with given status present in the collection!");
            }

            return recievers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!this.byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are no transactions with given status present in the collection!");
            }

            List<string> senders = this.byStatus[status]
                .OrderByDescending(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            if (senders.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with given status present in the collection!");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.byId.ContainsKey(id))
            {
                throw new InvalidOperationException("Non existant id provided!");
            }
            return this.byId[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> wantedTr = this.byId
                .Values
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo)
                .Where(t => t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (wantedTr.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return wantedTr;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> result = this.byId
                .Values
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> wantedTr = this.byId
                .Values
                .Where(t => t.From == sender)
                .Where(t => t.Amount > amount)
                .OrderByDescending(t => t.Amount);

            if (wantedTr.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return wantedTr;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> result = this.byId
                .Values
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!this.byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are no transactions with given status present in the collection!");
            }

            HashSet<ITransaction> wantedTr = this.byStatus[status];

            if (wantedTr.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with given status present in the collection!");
            }

            return wantedTr.OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.byId
                .Values
                .Where(t => t.Status == status)
                .Where(t => t.Amount <= amount)
                .OrderByDescending(t => t.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return this.byId.Values.GetEnumerator();
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.byId.ContainsKey(id))
            {
                throw new InvalidOperationException("You can not remove non-existing transaction!");
            }

            ITransaction tr = this.byId[id];

            this.byStatus[tr.Status].Remove(tr);
            this.byId.Remove(tr.Id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.byId.Values.GetEnumerator();
        }
    }
}
