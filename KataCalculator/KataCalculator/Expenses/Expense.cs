using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Expenses
{
    public class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public RelativeType ExpenseType { get; set; }
        public int UPC { get; set; }

        public Expense(string description, decimal amount, RelativeType type, int uPC)
        {
            Description = description;
            Amount = amount;
            ExpenseType = type;
            UPC = uPC;
        }
        public override string ToString()
        {
            return this.Description+": $"+this.Amount;
        }
    }
}
