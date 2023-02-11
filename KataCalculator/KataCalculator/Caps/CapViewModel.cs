using KataCalculator.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Caps
{
    public class CapViewModel
    {
        public List<Cap> list { get; set; }

        public CapViewModel()
        {
            list = CapRepository.GetAll();
        }

        public Cap FindUPCCap(int UPC)
        {
            Cap cap= list.Where(cap => cap.UPC == UPC).Select(cap => cap).FirstOrDefault();
            return cap;
        }
    }
}
