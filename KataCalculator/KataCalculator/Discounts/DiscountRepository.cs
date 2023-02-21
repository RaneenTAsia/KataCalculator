namespace KataCalculator.Discounts
{
    public class DiscountRepository
    {
        #region GetAll Method
        public static List<SelectiveDiscount> GetAll()
        {
            return new List<SelectiveDiscount>
            {
              new SelectiveDiscount(39846, 7M, DiscountType.Common),
              new SelectiveDiscount(2637458, 15M, DiscountType.Precedence)
            };
        }
        #endregion
    }
}
