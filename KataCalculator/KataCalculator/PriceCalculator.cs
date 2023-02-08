﻿using System;
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
        public decimal TaxedPrice { get; set; }
        public Product product { get; set; }
        static decimal _discountPercent = 0M;
        public static decimal DiscountPercent { get { return _discountPercent; } set { _discountPercent = value; } }
        public PriceCalculator() { }

        public PriceCalculator(Product product)
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
        public decimal CalculateDiscount()
        {
            return Math.Round(DiscountPercent / 100 * product.BasePrice, 2);
        }

        public decimal CalculateDiscountedPrice()
        {
            return Math.Round(product.BasePrice - CalculateDiscount(), 2);
        }

    }
}
