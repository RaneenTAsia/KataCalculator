using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator
{
    public class TaxCalculations
    {
        static decimal _taxPercent = 20M;
        public decimal TaxPercent { get { return _taxPercent; } set { _taxPercent = value; } }
        public decimal TaxedPrice { get; set; }
        public Product product { get; set; }
        public TaxCalculations() { }

        public TaxCalculations(Product product)
        {
            this.product = product;
            TaxedPrice=CalculateTaxPrice();
        }

        public decimal CalculateTaxValue()
        {
            return Math.Round(product.BasePrice * (TaxPercent / 100), 2);
        }

        private decimal CalculateTaxPrice()
        {
            return CalculateTaxValue() + product.BasePrice;
        }
        public static void ChangeTax(decimal tax)
        {
            _taxPercent = tax;
        }

    }
}
