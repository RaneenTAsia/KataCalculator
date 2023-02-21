namespace KataCalculator.Expenses
{
    public class ExpenseRepository
    {
        #region GetAll Method
        public static List<Expense> GetAll()
        {
            return new List<Expense>
            {
              new Expense("Packaging", 0.01M, RelativeType.Percent, 39846),
              new Expense("Transport", 2.20M, RelativeType.Absolute, 39846)
            };
        }
        #endregion
    }
}
