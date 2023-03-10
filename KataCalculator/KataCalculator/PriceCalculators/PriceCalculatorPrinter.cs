using KataCalculator.Caps;
using KataCalculator.Expenses;
using KataCalculator.Products;

namespace KataCalculator.PriceCalculators
{
    public class PriceCalculatorPrinter
    {
        public PriceCalculator PriceCalculator { get; set; }
        public string Currency { get; set; }
        public ExpenseService ExpenseService { get; set; }
        public CapService CapViewModel { get; set; }

        public PriceCalculatorPrinter(PriceCalculatorPrinterConfigurations priceCalculatorPrinterConfigurations)
        {
            PriceCalculator = priceCalculatorPrinterConfigurations.PriceCalculator;
            Currency = priceCalculatorPrinterConfigurations.Currency;
            ExpenseService = priceCalculatorPrinterConfigurations.ExpenseService;
            CapViewModel = priceCalculatorPrinterConfigurations.CapService;
        }

        public void printCalculations(Product product)
        {
            PriceCalculator.SelectiveDiscounService.GetAll();

            Cap? cap = CapViewModel.FindUPCCap(product.UPC);

            Console.WriteLine($"Name: {product.Name}, UPC: {product.UPC}, Price Before: {product.BasePrice.DecimalPlaces(2).AddCurrency(Currency)}");
            Console.WriteLine($"Tax = {PriceCalculator.TaxPercent.DecimalPlaces(2)}%, " +
                $"Tax amount = {PriceCalculator.CalculateTaxValue(product).DecimalPlaces(2).AddCurrency(Currency)}, " +
                $"Discount amount = {PriceCalculator.CalculateDiscountAmount(product, PriceCalculator.CombinationType, cap).DecimalPlaces(2).AddCurrency(Currency)}");

            decimal ExpenseSum = 0;
            foreach (Expense expense in ExpenseService.FindUPCExpense(product.UPC))
            {
                if (expense.ExpenseType == RelativeType.Percent)
                {
                    decimal ExpenseValue = PriceCalculator.CalculatePercentExpenseValue(product, expense);
                    Console.WriteLine(expense.Description + " = " + ExpenseValue.DecimalPlaces(2).AddCurrency(Currency));
                    ExpenseSum += ExpenseValue;
                }
                else
                {
                    decimal ExpenseValue = expense.Amount;
                    Console.WriteLine(expense.Description + " = " + ExpenseValue.DecimalPlaces(2).AddCurrency(Currency));
                    ExpenseSum += ExpenseValue;
                }
            }

            Console.WriteLine($"Price After = {PriceCalculator.CalculateTotalPrice(product, ExpenseSum, PriceCalculator.CombinationType, cap).DecimalPlaces(2).AddCurrency(Currency)}");
        }
    }
}
