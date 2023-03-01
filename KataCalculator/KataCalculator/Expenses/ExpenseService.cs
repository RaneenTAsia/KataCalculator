namespace KataCalculator.Expenses
{
    public class ExpenseService
    {
        public readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository= expenseRepository;
        }

        public IEnumerable<Expense> FindUPCExpense(int UPC)
        {
            return _expenseRepository.FindUPCExpense(UPC);
        }
    }
}
