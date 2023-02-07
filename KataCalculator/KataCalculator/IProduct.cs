namespace KataCalculator
{
    public interface IProduct
    {
        decimal BasePrice { get; set; }
        string Name { get; set; }
        int UPC { get; set; }

        string ToString();
    }
}