using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Discounts
{
    public class SelectiveDiscountViewModel
    {
        public List<SelectiveDiscount> list { get; set; }

        public SelectiveDiscountViewModel()
        {
            list = DiscountRepository.GetAll();
        }

        public SelectiveDiscount FindUPCDiscount(int UPC)
        {
            return list.Where(discount => discount.UPC == UPC).Select(discount => discount).FirstOrDefault();
        }
    }
}
