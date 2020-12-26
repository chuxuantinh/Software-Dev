using Chainblock.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private const int id = 1;
        private const TransactionStatus ts = TransactionStatus.Successfull;
        private const string from = "Pesho";
        private const string to = "Gosho";
        private const double amount = 650;

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Transaction tr = new Transaction(id, ts, from, to, amount);

            Assert.AreEqual(id, tr.Id);
            Assert.AreEqual(ts, tr.Status);
            Assert.AreEqual(from, tr.From);
            Assert.AreEqual(to, tr.To);
            Assert.AreEqual(amount, tr.Amount);
        }

        [Test]
        public void TestWithNegativeId()
        {
            int negativeId = -5;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(negativeId, ts, from, to, amount);
            });
        }

        [Test]
        public void TestWithWhitespaceFrom()
        {
            string whiteSpaceFrom = "  ";

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, whiteSpaceFrom, to, amount);
            });
        }

        [Test]
        public void TestWithWithespaceTo()
        {
            string whiteSpaceTo = "  ";

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, whiteSpaceTo, amount);
            });
        }

        [Test]
        public void TestWithZeroAmount()
        {
            double zeroAmount = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, to, zeroAmount);
            });
        }

        [Test]
        public void TestWithNegativeAmount()
        {
            double negativeAmount = -5;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, to, negativeAmount);
            });
        }

        [Test]
        public void TestCompareToWithDifferentId()
        {
            Transaction tr1 = new Transaction(id, ts, from, to, amount);
            Transaction tr2 = new Transaction(2, ts, from, to, amount);

            Assert.That(tr1.CompareTo(tr2) != 0);
        }

        [Test]
        public void TestCompareToWithSameIdAndDifferentStatus()
        {
            Transaction tr1 = new Transaction(id, ts, from, to, amount);
            Transaction tr2 = new Transaction(id, TransactionStatus.Unauthorized, from, to, amount);

            Assert.Throws<ArgumentException>(() => tr1.CompareTo(tr2));
        }

        [Test]
        public void TestCompareToWithSameIdAndDifferentSender()
        {
            Transaction tr1 = new Transaction(id, ts, from, to, amount);
            Transaction tr2 = new Transaction(id, ts, "Vanko", to, amount);

            Assert.Throws<ArgumentException>(() => tr1.CompareTo(tr2));
        }

        [Test]
        public void TestCompareToWithSameIdAndDifferentReceiver()
        {
            Transaction tr1 = new Transaction(id, ts, from, to, amount);
            Transaction tr2 = new Transaction(id, ts, from, "Vanko", amount);

            Assert.Throws<ArgumentException>(() => tr1.CompareTo(tr2));
        }

        [Test]
        public void TestCompareToWithSameIdAndDifferentAmount()
        {
            Transaction tr1 = new Transaction(id, ts, from, to, amount);
            Transaction tr2 = new Transaction(id, ts, from, to, amount + 10);

            Assert.Throws<ArgumentException>(() => tr1.CompareTo(tr2));
        }

        [Test]
        public void TestCompareToWithSameTransaction()
        {
            Transaction tr1 = new Transaction(id, ts, from, to, amount);
            Transaction tr2 = new Transaction(id, ts, from, to, amount);

            Assert.That(tr1.CompareTo(tr2) == 0);
        }
    }
}
