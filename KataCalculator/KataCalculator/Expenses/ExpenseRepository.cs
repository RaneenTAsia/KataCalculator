namespace KataCalculator.Expenses
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly List<Expense> _expensesList =
            new List<Expense>
            {
              new Expense("Packaging", 0.01M, RelativeType.Percent, 39846),
              new Expense("Transport", 2.20M, RelativeType.Absolute, 39846)
            };

        #region GetAll Method
        public List<Expense> GetAll()
        {
            return _expensesList;
        }
        #endregion

        public IEnumerable<Expense> FindUPCExpense(int UPC)
        {
            return _expensesList.Where(expense => expense.UPC == UPC).Select(discount => discount).ToList();
        }
    }
}
