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
