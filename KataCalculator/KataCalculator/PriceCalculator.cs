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
            if (DiscountList.FindUPCDiscount(product.UPC) != null && DiscountList.FindUPCDiscount(product.UPC).GetType() == typeof(PrecedenceSelectiveDiscount))
            return ((product.BasePrice-CalculateUPCDiscount()) * (TaxPercent / 100)).DecimalPlaces(2);
            else
            return (product.BasePrice * (TaxPercent / 100)).DecimalPlaces(2);
        }

        public decimal CalculateDiscount()
        {
            return (DiscountPercent / 100 * product.BasePrice).DecimalPlaces(2);
        }

        public decimal CalculateUPCDiscount()
        {
            decimal? UPCDiscount = 0M;
            if (DiscountList.FindUPCDiscount(product.UPC)!=null)
            UPCDiscount=DiscountList.FindUPCDiscount(product.UPC).DiscountPercent;
            if(UPCDiscount != 0)
            return ((decimal)UPCDiscount / 100 * product.BasePrice).DecimalPlaces(2);
            else
            return 0;

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
