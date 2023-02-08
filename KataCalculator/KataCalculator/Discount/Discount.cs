using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Discount
{
    public class Discount : IDiscount
    {
        static decimal _discountPercent = 0M;
        public static decimal DiscountPercent { get { return _discountPercent; } set { _discountPercent = value; } }
        public decimal Price { get; set; }
        public Discount()
        {
        }

        public Discount(decimal Price)
        {
            this.Price = Price;
        }

        public decimal CalculateDiscount()
        {
            return Math.Round(DiscountPercent / 100 * Price, 2);
        }

        public decimal CalculateDiscountedPrice()
        {
            return Math.Round(Price - CalculateDiscount(), 2);
        }
    }
}
