﻿using System;
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

        public Product()
        {
        }

        public Product(string name, int UPC, decimal Price)
        {
            Name = name;
            this.UPC = UPC;
            this.BasePrice = Price;
        }

        override public string ToString()
        {
            return $"Name: {Name}, UPC: {UPC}, Price: {BasePrice}";
        }

    }
}
