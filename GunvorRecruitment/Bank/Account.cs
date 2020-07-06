using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorRecruitment.Bank
{
    public class Account
    {
        public decimal Balance { get; protected set; }

        public string PersonName { get; set; }

        public List<Transaction> Transactions { get; set; }

        public virtual void Deposit(decimal amount)
        {
            var tempValue = Balance;
            var newValue = tempValue + amount;
            Balance = newValue;

            Transaction transaction = new Transaction("Deposit", amount, DateTime.Now);
            Transactions.Add(transaction);
        }

        public virtual void Withdraw(decimal amount)
        {
            var tempValue = Balance;
            var newValue = tempValue - amount;
            Balance = newValue;

            Transaction transaction = new Transaction("Withdraw", amount, DateTime.Now);
            Transactions.Add(transaction);
        }

        public string ShowTransactionHistory()
        {
            string transactionSummary = "";
            foreach (var transaction in Transactions)
            {
                transactionSummary = transaction.Display() + "\n";
            }
            return transactionSummary;
        }
    }
}
