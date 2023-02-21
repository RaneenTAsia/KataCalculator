namespace KataCalculator.Discounts
{
    public class SelectiveDiscount
    {
        public decimal DiscountPercent { get; set; }
        public int UPC { get; set; }
        public DiscountType DiscountType { get; set; }

        public SelectiveDiscount(int UPC, decimal DiscountPercent, DiscountType type)
        {
            this.DiscountPercent = DiscountPercent;
            this.UPC = UPC;
            DiscountType = type;
        }
    }
}
