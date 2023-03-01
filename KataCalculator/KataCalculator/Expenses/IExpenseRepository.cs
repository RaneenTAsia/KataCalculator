namespace KataCalculator.Expenses
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> FindUPCExpense(int UPC);
        List<Expense> GetAll();
    }
}