using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataCalculator.Discounts;
using KataCalculator.Products;

namespace KataCalculator
{
    public class PriceCalculator
    {
        public decimal TaxPercent { get; set; } = 20M;
        public decimal DiscountPercent { get; set; } = 0M;
        public SelectiveDiscountViewModel SelectiveDiscountViewModel { get; set; }

        public PriceCalculator()
        {
            SelectiveDiscountViewModel = new SelectiveDiscountViewModel();
        }

        public decimal CalculateTaxValue(Product product)
        {
            if (IsPrecedenceDiscount(product))
                return ((product.BasePrice - CalculateUPCDiscount(product)) * (TaxPercent / 100)).DecimalPlaces(2);
            else
                return (product.BasePrice * (TaxPercent / 100)).DecimalPlaces(2);
        }

        private bool IsPrecedenceDiscount(Product product)
        {
            SelectiveDiscount? discount = SelectiveDiscountViewModel.FindUPCDiscount(product.UPC);
            return discount != null && discount.DiscountType == DiscountType.Precedence;
        }

        public decimal CalculateDiscount(Product product)
        {
            return (DiscountPercent / 100 * product.BasePrice).DecimalPlaces(2);
        }

        public decimal CalculateUPCDiscount(Product product)
        {
            decimal? UPCDiscount = 0M;
            if (SelectiveDiscountViewModel.FindUPCDiscount(product.UPC)!=null)
            UPCDiscount=SelectiveDiscountViewModel.FindUPCDiscount(product.UPC).DiscountPercent;
            if(UPCDiscount != 0)
            return ((decimal)UPCDiscount / 100 * product.BasePrice).DecimalPlaces(2);
            else
            return 0;

        }

        public decimal AccumulativeDiscountAmount(Product product)
        {
            return CalculateUPCDiscount(product) + CalculateDiscount(product);
        }

        public decimal CalculateGeneralDiscountedAndTaxedPrice(Product product)
        {
            decimal value= product.BasePrice+ CalculateTaxValue(product)-AccumulativeDiscountAmount(product);
            return value;
        }

        public void printCalculations(Product product)
        {
            Console.WriteLine(product.ToString());
            Console.WriteLine($"Tax={TaxPercent}%, " +
            $"Tax amount=${CalculateTaxValue(product)}, Discount amount=${AccumulativeDiscountAmount(product)}");
            Console.WriteLine($"Price before = ${product.BasePrice}, price after = ${CalculateGeneralDiscountedAndTaxedPrice(product)}");
        }

    }
}
