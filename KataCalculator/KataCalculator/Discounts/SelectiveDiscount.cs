﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Discounts
{
    public class SelectiveDiscount : ISelectiveDiscount
    {
        public decimal DiscountPercent { get; set; }
        public int UPC { get; set; }

        public SelectiveDiscount(int UPC, decimal DiscountPercent)
        {
            this.DiscountPercent = DiscountPercent;
            this.UPC = UPC;
        }
    }
}