namespace KataCalculator.PriceCalculators
{
    public class PriceCalculatorPrinterConfigurations
    {
        public PriceCalculator PriceCalculator { get; set; }
        public string Currency { get; set; }

        public PriceCalculatorPrinterConfigurations(PriceCalculator priceCalculator, string currency)
        {
            PriceCalculator = priceCalculator;
            Currency = currency == "" ? "USD" : currency;
        }
    }
}
