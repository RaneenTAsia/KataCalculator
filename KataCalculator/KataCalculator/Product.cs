using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator
{
    public class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TaxPrice { get; private set; }
        decimal _taxPercent = 20M;

        public decimal TaxPercent
        {
            get { return _taxPercent; }
            set
            { 
                _taxPercent = value;
                TaxPrice = CalculateTaxPrice();
            }
        }

        public Product()
        {
        }

        public Product(string name, int UPC, decimal Price)
        {
            Name = name;
            this.UPC = UPC;
            this.BasePrice = Price;
            TaxPrice= CalculateTaxPrice();
        }

        public decimal CalculateTaxValue()
        {
            return Math.Round(this.BasePrice * (TaxPercent / 100), 2);
        }

        private decimal CalculateTaxPrice()
        {
            return CalculateTaxValue()+this.BasePrice;
        }

        override public string ToString()
        { 
            return $"Name: {Name}, UPC: {UPC}, Price: {BasePrice}";
        }
    }
}
