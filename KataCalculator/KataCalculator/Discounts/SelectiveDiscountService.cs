using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Discounts
{
    public class SelectiveDiscountService
    {
        public readonly IDiscountRepository _discountRepository;

        public SelectiveDiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public List<SelectiveDiscount> GetAll()
        {
            return _discountRepository.GetAll();
        }

        public SelectiveDiscount? FindUPCDiscount(int UPC)
        {
            return _discountRepository.FindUPCDiscount(UPC);
        }
    }
}
