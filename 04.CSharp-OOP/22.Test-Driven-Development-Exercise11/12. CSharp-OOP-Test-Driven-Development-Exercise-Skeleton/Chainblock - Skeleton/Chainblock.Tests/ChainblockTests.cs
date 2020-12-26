using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private const int id = 1;
        private const TransactionStatus ts = TransactionStatus.Successfull;
        private const string from = "Pesho";
        private const string to = "Gosho";
        private const double amount = 650;
        private Models.Chainblock chainblock;
        private Transaction transaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Models.Chainblock();
            this.transaction = new Transaction(id, ts, from, to, amount);
            this.chainblock.Add(this.transaction);
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void TestAddingSameTransactionTwice()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.Add(this.transaction)); 
        }

        [Test]
        public void TestIfContainsByTransactionWorksCorrectly()
        {
            bool actualResult = this.chainblock.Contains(this.transaction);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void TestContainsNonExistantTransaction()
        {
            Transaction nonExistantTr = new Transaction(10, TransactionStatus.Unauthorized, from, to, amount);

            bool result = this.chainblock.Contains(nonExistantTr);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestContainsById()
        {
            bool result = this.chainblock.Contains(id);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestContainsNonExistantId()
        {
            bool result = this.chainblock.Contains(5);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestContainsWithNegativeId()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.Contains(-5));
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            int expectedCount = 2;
            Transaction newTr = new Transaction(10, TransactionStatus.Unauthorized, from, to, amount);
            this.chainblock.Add(newTr);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void TestIfGetByIdWorksCorrectly()
        {
            ITransaction result = this.chainblock.GetById(id);

            Assert.AreSame(this.transaction, result);
            Assert.AreEqual(this.transaction.Id, result.Id);
        }

        [Test]
        public void TestGettingNonExistantTransaction()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(5));
        }

        [Test]
        public void TestIfChangeTransactionStatusWorksCorrectly()
        {
            TransactionStatus newStatus = TransactionStatus.Aborted;
            this.chainblock.ChangeTransactionStatus(id, newStatus);
            ITransaction result = this.chainblock.GetById(id);

            Assert.AreEqual(newStatus, result.Status);
        }

        [Test]
        public void TestChangingStatusOnNonExistantTransaction()
        {
            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(5, TransactionStatus.Failed));
        }

        [Test]
        public void TestRemovingByIdCorrectly()
        {
            int expectedCount = 0;
            this.chainblock.RemoveTransactionById(id);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void TestRemovingNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(5));
        }

        [Test]
        public void TestIfGetByStatusReturnsAllWithIntendedStatus()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatus(ts);

            bool result = resultCollection.All(t => t.Status == ts);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByStatusReturnsCollectionWithCorrectCount()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatus(ts);

            int actualCount = resultCollection.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestIfGetByStatusReturnedCollectionContainsOnlyOurTransactions()
        {
            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatus(ts);

            Assert.AreSame(this.transaction, resultCollection.First());
        }

        [Test]
        public void TestIfGetByStatusReturnsTransactionsOrderedCorrectly()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            List<ITransaction> resultCollection = this.chainblock
                .GetByTransactionStatus(ts)
                .ToList();

            bool areOrdered = true;
            double currentMax = resultCollection
                .First()
                .Amount;

            for (int i = 1; i < resultCollection.Count(); i++)
            {
                ITransaction currentTransaction = resultCollection[i];

                if (currentTransaction.Amount > currentMax)
                {
                    areOrdered = false;
                }

                currentMax = currentTransaction.Amount;
            }

            Assert.IsTrue(areOrdered);
        }

        [Test]
        public void TestGetByNonExistingStatus()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void TestIfGetAllSendersWithTransactionStatusReturnsCorrectCount()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            IEnumerable<string> result = this.chainblock.GetAllSendersWithTransactionStatus(ts);

            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void TestIfGetAllSendersWithTransactionStatusReturnsCorrectCollection()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            string[] expectedCollection = this.chainblock
                .GetByTransactionStatus(ts)
                .Select(t => t.From)
                .ToArray();
            IEnumerable<string> actualCollection = this.chainblock.GetAllSendersWithTransactionStatus(ts);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void TestGettingAllSendersWithNonExistingTransactionStatus()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void TestIfGetAllRecieversWithTransactionStatusReturnsCorrectCount()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            IEnumerable<string> result = this.chainblock.GetAllReceiversWithTransactionStatus(ts);

            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void TestIfGetAllRecieversWithTransactionStatusReturnsCorrectCollection()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            string[] expectedCollection = this.chainblock
                .GetByTransactionStatus(ts)
                .Select(t => t.To)
                .ToArray();
            IEnumerable<string> actualCollection = this.chainblock.GetAllReceiversWithTransactionStatus(ts);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void TestGettingAllRecieversWithNonExistingTransactionStatus()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void TestIfGetAllOrderedByAmountDescendingThenByIdReturnsOrderedCollection()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            List<ITransaction> resultCollection = this.chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToList();

            bool areOrdered = true;
            double currentMax = resultCollection
                .First()
                .Amount;
            int currentId = resultCollection
                .First()
                .Id;

            for (int i = 1; i < resultCollection.Count(); i++)
            {
                ITransaction currentTransaction = resultCollection[i];

                if (currentTransaction.Amount > currentMax)
                {
                    areOrdered = false;
                }
                else if (currentTransaction.Amount == currentMax)
                {
                    if (currentTransaction.Id < currentId)
                    {
                        areOrdered = false;
                    }
                }

                currentMax = currentTransaction.Amount;
                currentId = currentTransaction.Id;
            }

            Assert.IsTrue(areOrdered);
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingReturnsCorrectCount()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetBySenderOrderedByAmountDescending(from);

            Assert.AreEqual(expectedCount, resultCollection.Count());
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingReturnsCollectionWithCorrectSenderNames()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetBySenderOrderedByAmountDescending(from);

            bool result = resultCollection.All(t => t.From == from);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingReturnsOrderedCollection()
        {
            Transaction tr1 = new Transaction(2, ts, from, to, amount + 10);
            Transaction tr2 = new Transaction(3, ts, from, to, amount + 20);

            this.chainblock.Add(tr1);
            this.chainblock.Add(tr2);
            this.chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr2,
                tr1,
                this.transaction
            };

            List<ITransaction> resultCollection = this.chainblock.GetBySenderOrderedByAmountDescending(from).ToList();

            CollectionAssert.AreEqual(expectedResult, resultCollection);
        }

        [Test]
        public void TestGetBySenderOrderedByAmountDescendingWithNonExistingSender()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderOrderedByAmountDescending("Vanko"));
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountThenByIdReturnsCorrectCount()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByReceiverOrderedByAmountThenById(to);

            Assert.AreEqual(expectedCount, resultCollection.Count());
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountThenByIdReturnsCollectionWithCorrectRecieverNames()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByReceiverOrderedByAmountThenById(to);

            bool result = resultCollection.All(t => t.To == to);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountThenByIdReturnsOrderedCollection()
        {
            Transaction tr1 = new Transaction(2, ts, from, to, amount);
            Transaction tr2 = new Transaction(3, ts, from, to, amount + 20);

            this.chainblock.Add(tr1);
            this.chainblock.Add(tr2);
            this.chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr2,
                this.transaction,
                tr1,
            };

            List<ITransaction> resultCollection = this.chainblock.GetByReceiverOrderedByAmountThenById(to).ToList();

            CollectionAssert.AreEqual(expectedResult, resultCollection);
        }

        [Test]
        public void TestGetByReceiverOrderedByAmountThenByIdWithNonExistingReciever()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverOrderedByAmountThenById("Vanko"));
        }

        [Test]
        public void TestIfGetByTransactionStatusAndMaximumAmountReturnsCorrectTransactions()
        {
            double maxAmount = amount + 20;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Unauthorized, from, to, amount));
            this.chainblock.Add(new Transaction(5, ts, from, to, amount + 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatusAndMaximumAmount(ts, maxAmount);

            bool result = resultCollection.All(t => t.Status == ts && t.Amount <= maxAmount);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByTransactionStatusAndMaximumAmountReturnsOrderedCollection()
        {
            double maxAmount = amount + 20;

            Transaction tr1 = new Transaction(2, ts, from, to, amount + 10);
            Transaction tr2 = new Transaction(3, ts, from, to, amount + 20);
            Transaction tr3 = new Transaction(4, TransactionStatus.Unauthorized, from, to, amount);
            Transaction tr4 = new Transaction(5, ts, from, to, amount + 30);

            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr2,
                tr1,
                this.transaction
            };

            this.chainblock.Add(tr1);
            this.chainblock.Add(tr2);
            this.chainblock.Add(tr3);
            this.chainblock.Add(tr4);

            List<ITransaction> actualResult = this.chainblock.GetByTransactionStatusAndMaximumAmount(ts, maxAmount).ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestGetByTransactionStatusAndMaximumAmountWithNonExistingStatus()
        {
            IEnumerable<ITransaction> result = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, 200);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TestGetByTransactionStatusAndMaximumAmountWithNonExistingAmount()
        {
            IEnumerable<ITransaction> result = this.chainblock.GetByTransactionStatusAndMaximumAmount(ts, amount - 10);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TestGetBySenderAndMinimumAmountDescendingReturnsIntendedTransactions()
        {
            double minAmount = amount - 10;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, "Vanko", to, amount));
            this.chainblock.Add(new Transaction(5, ts, from, to, amount - 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetBySenderAndMinimumAmountDescending(from, minAmount);

            bool result = resultCollection.All(t => t.From == from && t.Amount >= minAmount);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetBySenderAndMinimumAmountDescendingReturnsOrderedCollection()
        {
            double minAmount = amount - 10;

            Transaction tr1 = new Transaction(2, ts, from, to, amount + 10);
            Transaction tr2 = new Transaction(3, ts, from, to, amount + 20);
            Transaction tr3 = new Transaction(4, ts, "Vanko", to, amount);
            Transaction tr4 = new Transaction(5, ts, from, to, amount - 30);

            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr2,
                tr1,
                this.transaction
            };

            this.chainblock.Add(tr1);
            this.chainblock.Add(tr2);
            this.chainblock.Add(tr3);
            this.chainblock.Add(tr4);

            List<ITransaction> actualResult = this.chainblock.GetBySenderAndMinimumAmountDescending(from, minAmount).ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestGetBySenderAndMinimumAmountDescendingWithNonExistingSender()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending("Vanko", amount - 10));
        }

        [Test]
        public void TestGetBySenderAndMinimumAmountDescendingWithInvalidAmount()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending(from, amount + 10));
        }

        [Test]
        public void TestGetAllInAmountRangeWorksCorrectly()
        {
            double minAmount = amount + 5;
            double maxAmount = amount + 25;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetAllInAmountRange(minAmount, maxAmount);

            bool result = resultCollection.All(t => t.Amount >= minAmount && t.Amount <= maxAmount);

            Assert.AreEqual(2, resultCollection.Count());
            Assert.IsTrue(result);
        }

        [Test]
        public void TestGetAllInAmountRangeWhenThereAreNoTransactionsCorrespondingToGivenRange()
        {
            double minAmount = amount + 35;
            double maxAmount = amount + 55;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetAllInAmountRange(minAmount, maxAmount);

            CollectionAssert.IsEmpty(resultCollection);
        }

        [Test]
        public void TestGetEnumerator()
        {
            int expectedCount = 1;
            int count = 0;

            foreach (var cb in this.chainblock)
            {
                count++;
            }

            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void TestIfGetByReceiverAndAmountRangeReturnsIntendedTransactions()
        {
            double minAmount = amount;
            double maxAmount = amount + 20;

            Transaction tr1 = new Transaction(7, ts, from, to, amount + 10);
            Transaction tr2 = new Transaction(3, ts, from, to, amount + 20);
            Transaction tr3 = new Transaction(4, ts, from, "Vanko", amount + 10);
            Transaction tr4 = new Transaction(5, ts, from, to, amount + 19.57);
            Transaction tr5 = new Transaction(6, ts, from, to, amount - 0.33);
            Transaction tr6 = new Transaction(2, ts, from, to, amount + 10);

            this.chainblock.Add(tr1);
            this.chainblock.Add(tr2);
            this.chainblock.Add(tr3);
            this.chainblock.Add(tr4);
            this.chainblock.Add(tr5);
            this.chainblock.Add(tr6);

            List<ITransaction> resultCollection = this.chainblock.GetByReceiverAndAmountRange(to, minAmount, maxAmount).ToList();

            bool result = resultCollection.All(t => t.To == to && t.Amount >= minAmount && t.Amount < maxAmount);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByReceiverAndAmountRangeReturnsOrderedTransactions()
        {
            double minAmount = amount;
            double maxAmount = amount + 20;

            Transaction tr1 = new Transaction(7, ts, from, to, amount + 10);
            Transaction tr2 = new Transaction(3, ts, from, to, amount + 20);
            Transaction tr3 = new Transaction(4, ts, from, "Vanko", amount + 10);
            Transaction tr4 = new Transaction(5, ts, from, to, amount + 19.57);
            Transaction tr5 = new Transaction(6, ts, from, to, amount - 0.33);
            Transaction tr6 = new Transaction(2, ts, from, to, amount + 10);

            this.chainblock.Add(tr1);
            this.chainblock.Add(tr2);
            this.chainblock.Add(tr3);
            this.chainblock.Add(tr4);
            this.chainblock.Add(tr5);
            this.chainblock.Add(tr6);

            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr4,
                tr6,
                tr1,
                this.transaction
            };

            List<ITransaction> actualResult = this.chainblock.GetByReceiverAndAmountRange(to, minAmount, maxAmount).ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestGetByReceiverAndAmountRangeWithNonExistingReceiver()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverAndAmountRange("Vanko", amount -10, amount +10));
        }

        [Test]
        public void TestGetByReceiverAndAmountRangeWithNonExistingAmountRange()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverAndAmountRange(to, amount - 10, amount - 5));
        }
    }
}
