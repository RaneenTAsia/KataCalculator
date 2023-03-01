namespace KataCalculator.Discounts
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly List<SelectiveDiscount> selectiveDiscounts =
            new List<SelectiveDiscount>
            {
              new SelectiveDiscount(39846, 7M, DiscountType.Common),
              new SelectiveDiscount(2637458, 15M, DiscountType.Precedence)
            };

        #region GetAll Method
        public List<SelectiveDiscount> GetAll()
        {
            return selectiveDiscounts;
        }
        #endregion

        public SelectiveDiscount? FindUPCDiscount(int UPC)
        {
            return selectiveDiscounts.Where(discount => discount.UPC == UPC).Select(discount => discount).FirstOrDefault();
        }
    }
}
