using KataCalculator.Caps;
using KataCalculator.Expenses;

namespace KataCalculator.PriceCalculators
{
    public class PriceCalculatorPrinterConfigurations
    {
        public PriceCalculator PriceCalculator { get; set; }
        public string Currency { get; set; }
        public ExpenseService ExpenseService { get; set; }
        public CapService CapService { get; set; }

        public PriceCalculatorPrinterConfigurations(PriceCalculator priceCalculator, string currency, ExpenseService expenseService, CapService capService)
        {
            PriceCalculator = priceCalculator;
            Currency = currency == "" ? "USD" : currency;
            ExpenseService = expenseService;
            CapService = capService;
        }
    }
}
