using GunvorRecruitment.Bank;
using System;
using System.Collections.Generic;

namespace GunvorRecruitment.Bank
{
    public class CurrentAccount : Account
    {
        public int OverDraft { get; set; }

        public override void Withdraw(decimal amount)
        {
            if (amount > OverDraft)
                throw new AccountOverDrawnException();

            var tempValue = Balance;
            var newValue = tempValue - amount;
            Balance = newValue;

            Transaction transaction = new Transaction("Withdraw", amount, DateTime.Now);
            Transactions.Add(transaction);
        }

    }
}
