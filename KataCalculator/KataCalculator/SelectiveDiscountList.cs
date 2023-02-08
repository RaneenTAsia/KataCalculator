using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator
{
    public class SelectiveDiscountList
    {
        public List<SelectiveDiscount> list { get; set; }
        public SelectiveDiscountList()
        { 
            list = new List<SelectiveDiscount>();
        }
        public decimal FindUPCDiscount(int UPC)
        {
            return list.Where(discount=>discount.UPC == UPC).Select(discount=>discount.DiscountPercent).FirstOrDefault();
        }
        public void AddDiscount(SelectiveDiscount discount)
        {
            list.Add(discount);
        }
    }
}
