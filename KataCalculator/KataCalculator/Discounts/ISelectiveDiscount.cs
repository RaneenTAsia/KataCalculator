namespace KataCalculator.Discounts
{
    public interface ISelectiveDiscount
    {
        decimal DiscountPercent { get; set; }
        int UPC { get; set; }
    }
}