namespace KataCalculator.Discounts
{
    public interface IDiscountRepository
    {
        SelectiveDiscount? FindUPCDiscount(int UPC);
        List<SelectiveDiscount> GetAll();
    }
}