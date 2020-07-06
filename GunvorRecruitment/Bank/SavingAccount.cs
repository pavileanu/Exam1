using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorRecruitment.Bank
{
    public class SavingAccount : Account
    {
        private static int InterestPercentage = 2;

        public override void Withdraw(decimal amount)
        {
            if (HasAnyWithdrawThisMonth())
                throw new AlreadyWithdrawThisMonthException();

            var tempValue = Balance;
            var newValue = tempValue - amount;
            Balance = newValue;

            Transaction transaction = new Transaction("Withdraw", amount, DateTime.Now);
            Transactions.Add(transaction);
        }

        public void AddInterest()
        {
            Balance = ((decimal)SavingAccount.InterestPercentage + 100) / 100 * Balance; 
        }

        public void AddYearsInterest(int years)
        {
            if (!HasAnyWithdrawOrDepositThisYears(years))
                while (years > 0)
                {
                    AddInterest();
                    years--;
                }
        }

        public bool HasAnyWithdrawThisMonth()
        {
            return Transactions.Where(t => t.Name == "Withdraw" &&
                                      t.TransactionDate > DateTime.Now.AddDays(-30)).Any();
        }

        public bool HasAnyWithdrawOrDepositThisYears(int years)
        {
            return Transactions.Where(t => (t.Name == "Withdraw" || t.Name == "Deposit") &&
                               t.TransactionDate > DateTime.Now.AddYears(-years)).Any();
        }




    }
}
