using KataCalculator.Caps;
using KataCalculator.Discounts;
using KataCalculator.Expenses;
using KataCalculator.Products;

namespace KataCalculator.PriceCalculators
{
    public class PriceCalculator
    {
        public decimal TaxPercent { get; set; }
        public decimal DiscountPercent { get; set; }
        public SelectiveDiscountViewModel SelectiveDiscountViewModel { get; set; }
        public CombinationType CombinationType { get; set; }


        public PriceCalculator(PriceCalculatorConfigurations priceCalculatorConfigurations)
        {
            TaxPercent = priceCalculatorConfigurations.TaxConfiguration;
            DiscountPercent = priceCalculatorConfigurations.DiscountConfiguration;
            CombinationType = priceCalculatorConfigurations.CombinationTypeConfiguration;

            SelectiveDiscountViewModel = new SelectiveDiscountViewModel();
        }

        public decimal CalculateTaxValue(Product product)
        {
            if (IsPrecedenceDiscount(product))
                return ((product.BasePrice - CalculateUPCDiscount(product.UPC, product.BasePrice)) * (TaxPercent / 100)).DecimalPlaces(4);
            else
                return (product.BasePrice * (TaxPercent / 100M)).DecimalPlaces(4);
        }

        private bool IsPrecedenceDiscount(Product product)
        {
            SelectiveDiscount? discount = SelectiveDiscountViewModel.FindUPCDiscount(product.UPC);
            return discount != null && discount.DiscountType == DiscountType.Precedence;
        }

        public decimal CalculateDiscount(Product product)
        {
            return (DiscountPercent / 100M * product.BasePrice).DecimalPlaces(4);
        }

        public decimal CalculateUPCDiscount(int UPC, decimal BasePrice)
        {
            decimal UPCDiscount = 0M;
            if (SelectiveDiscountViewModel.FindUPCDiscount(UPC) != null)
                UPCDiscount = SelectiveDiscountViewModel.FindUPCDiscount(UPC).DiscountPercent;

            if (UPCDiscount != 0)
                return ((decimal)UPCDiscount / 100M * BasePrice).DecimalPlaces(4);
            else
                return 0;
        }

        public decimal CalculateAccumulativeDiscountAmount(Product product)
        {
            return (CalculateUPCDiscount(product.UPC, product.BasePrice) + CalculateDiscount(product)).DecimalPlaces(4);
        }

        public decimal CalculateMultiplicativeDiscountAmount(Product product)
        {
            decimal generalDiscount = CalculateDiscount(product);
            decimal generalDiscountedPrice = product.BasePrice - generalDiscount;
            return (generalDiscount + CalculateUPCDiscount(product.UPC, generalDiscountedPrice)).DecimalPlaces(4);
        }

        public decimal CalculateDiscountAmount(Product product, CombinationType combinationType, Cap? cap)
        {
            decimal discountAmount;

            if (combinationType == CombinationType.Multiplicative)
            {
                discountAmount = CalculateMultiplicativeDiscountAmount(product);
            }
            else
            {
                discountAmount = CalculateAccumulativeDiscountAmount(product);
            }

            if (cap != null)
            {
                decimal capAmount = CalculateCapAmount(product, cap);

                if (discountAmount > capAmount)
                {
                    discountAmount = capAmount;
                }
            }

            return discountAmount.DecimalPlaces(4);
        }

        public decimal CalculateTotalPrice(Product product, decimal ExpenseSum, CombinationType combinationType, Cap? cap)
        {
            return (product.BasePrice + CalculateTaxValue(product) - CalculateDiscountAmount(product, combinationType, cap) + ExpenseSum.DecimalPlaces(4)).DecimalPlaces(4);
        }

        public decimal CalculatePercentExpenseValue(Product product, Expense expense)
        {
            return (expense.Amount * product.BasePrice).DecimalPlaces(4);
        }

        public decimal CalculateCapAmount(Product product, Cap cap)
        {
            if (cap.RelativeType == RelativeType.Absolute)
            {
                return cap.Value.DecimalPlaces(4);
            }
            else
            {
                return (product.BasePrice * (cap.Value / 100)).DecimalPlaces(4);
            }
        }
    }
}
