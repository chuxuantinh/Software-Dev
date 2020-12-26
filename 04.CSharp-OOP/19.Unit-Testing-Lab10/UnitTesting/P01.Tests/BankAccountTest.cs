using NUnit.Framework;

namespace P01.Tests
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount bankAccount;

        [SetUp]
        public void CreateBankAccount()
        {
            bankAccount = new BankAccount(100m);
        }

        [TearDown]
        public void DestroyBankAccount()
        {
            bankAccount = null;
        }

        [Test]
        public void TestNewBankAccount()
        {
            Assert.That(bankAccount.Balance, Is.EqualTo(100m), "Creating a new bank account");
        }

        [Test]
        public void TestNewBankAccountWithNegativeBalance()
        {
            Assert.That(() => new BankAccount(-100m), Throws.ArgumentException.With.Message.EqualTo("Balance can not be negative"));
        }

        [Test]
        public void TestDeposit()
        {
            bankAccount.Deposit(100m);

            Assert.That(bankAccount.Balance, Is.EqualTo(200m));
        }

        [Test]
        public void TestDepositWithNegativeSum()
        {
            Assert.That(() => bankAccount.Deposit(-50m), Throws.ArgumentException);
        }

        [Test]
        public void TestWithdraw()
        {
            decimal balance = bankAccount.Withdraw(50m);

            Assert.That(balance == bankAccount.Balance);
        }

        [Test]
        public void TestWithdrawMoreThanBalance()
        {
            Assert.That(() => bankAccount.Withdraw(500m), Throws.ArgumentException.With.Message.EqualTo("Balance can not be negative"));
        }
    }
}
