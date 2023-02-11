using KataCalculator.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Expenses
{
    public class ExpenseRepository
    {
        #region GetAll Method
        public static List<Expense> GetAll()
        {
            return new List<Expense>
            {
              new Expense("Packaging", 0.20M, ExpenseType.Percent, 2637458),
              new Expense("Transport", 0.15M, ExpenseType.Absolute, 2637458)
            };
        }
        #endregion
    }
}
