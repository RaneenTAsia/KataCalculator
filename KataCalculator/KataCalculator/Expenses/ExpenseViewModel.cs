using KataCalculator.Discounts;
using KataCalculator.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Expenses
{
    public class ExpenseViewModel
    {
        public List<Expense> Expenses { get; set; }

        public ExpenseViewModel()
        {
            Expenses = ExpenseRepository.GetAll();
        }

        public IEnumerable<Expense> FindUPCExpense(int UPC)
        {
            return Expenses.Where(expense => expense.UPC == UPC).Select(discount => discount).ToList();
        }
    }
}
