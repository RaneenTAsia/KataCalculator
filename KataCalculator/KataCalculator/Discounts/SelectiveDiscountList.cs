using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Discounts
{
    public class SelectiveDiscountList
    {
        public List<ISelectiveDiscount> list { get; set; }
        public SelectiveDiscountList()
        {
            list = new List<ISelectiveDiscount>();
        }
        public ISelectiveDiscount FindUPCDiscount(int UPC)
        {
            return list.Where(discount => discount.UPC == UPC).Select(discount => discount).FirstOrDefault();
        }
        public void AddDiscount(ISelectiveDiscount discount)
        {
            list.Add(discount);
        }
    }
}
