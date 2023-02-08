using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator
{
    public class PriceCalculator
    {
        static decimal _taxPercent = 20M;
        public static decimal TaxPercent { get { return _taxPercent; } set { _taxPercent = value; } }
        public Product product { get; set; }
        static decimal _discountPercent = 0M;
        public static decimal DiscountPercent { get { return _discountPercent; } set { _discountPercent = value; } }
        public SelectiveDiscountList DiscountList { get; set; }
        public PriceCalculator() { }

        public PriceCalculator(Product product, SelectiveDiscountList DiscountList)
        {
            this.product = product;
            this.DiscountList = DiscountList;
        }

        public decimal CalculateTaxValue()
        {
            return Math.Round(product.BasePrice * (TaxPercent / 100), 2);
        }
        public decimal CalculateDiscount()
        {
            return Math.Round(DiscountPercent / 100 * product.BasePrice, 2);
        }

        public decimal CalculateUPCDiscount()
        {
            decimal UPCDiscount=DiscountList.FindUPCDiscount(product.UPC);
            return Math.Round(UPCDiscount / 100 * product.BasePrice, 2);

        }
        public decimal AccumulativeDiscountAmount()
        {
            return CalculateUPCDiscount() + CalculateDiscount();
        }
        public decimal CalculateGeneralDiscountedAndTaxedPrice()
        {
            decimal value= product.BasePrice+ CalculateTaxValue()-AccumulativeDiscountAmount();
            return value;
        }

    }
}
