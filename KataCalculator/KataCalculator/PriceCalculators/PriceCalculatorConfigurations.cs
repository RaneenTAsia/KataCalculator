using KataCalculator.Discounts;

namespace KataCalculator.PriceCalculators
{
    public class PriceCalculatorConfigurations
    {
        public decimal TaxConfiguration { get; set; }
        public decimal DiscountConfiguration { get; set; }
        public CombinationType CombinationTypeConfiguration { get; set; }
        public SelectiveDiscountService SelectiveDiscountService { get; set; }

        public PriceCalculatorConfigurations(decimal? taxConfiguration, decimal? discountConfiguration, CombinationType combinationTypeConfiguration, SelectiveDiscountService selectiveDiscountService)
        {
            TaxConfiguration = taxConfiguration == null ? 21M : (decimal)taxConfiguration;
            DiscountConfiguration = discountConfiguration == null ? 15M : (decimal)discountConfiguration;
            CombinationTypeConfiguration = combinationTypeConfiguration;
            SelectiveDiscountService = selectiveDiscountService;
        }
    }
}
