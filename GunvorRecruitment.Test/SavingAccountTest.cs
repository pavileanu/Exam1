using System;
using NUnit.Framework;
using GunvorRecruitment.Bank;
using System.Collections.Generic;

namespace GunvorRecruitment.Test
{
    [TestFixture]
    public class SavingAccountTest
    {
        private SavingAccount _subject;

        [Test]
        public void ShouldGetNewBalanceInYears()
        {
            _subject.Transactions.Clear();
            _subject.AddYearsInterest(10);
            Assert.AreEqual(121.90, Math.Round(_subject.Balance, 2));
        }

        [Test]
        public void ShouldThrowAlreadyWithdrawThisMonthException()
        {
            _subject.Withdraw(10);
            Assert.Throws<AlreadyWithdrawThisMonthException>(() => _subject.Withdraw(10));
        }

        [SetUp]
        public void SetUp()
        {
            _subject = new SavingAccount
            {
                PersonName = "Test Person",
                Transactions = new List<Transaction>()
            };

            _subject.Deposit(100);
        }
    }
}
