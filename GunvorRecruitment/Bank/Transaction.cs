using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorRecruitment.Bank
{
    public class Transaction
    {
        public string Name { get; }
        public decimal Amount { get; }

        public DateTime TransactionDate { get; }

        public Transaction(string Name, decimal Amount, DateTime TransactionDate)
        {
            this.Name = Name;
            this.Amount = Amount;
            this.TransactionDate = TransactionDate;
        }

        public string Display()
        {
            return string.Format("Type = {0} Amount = {1} Date = {2}",
                                 Name, Amount, TransactionDate.ToString("MM/dd/yyyy"));     
        }
    }
}
