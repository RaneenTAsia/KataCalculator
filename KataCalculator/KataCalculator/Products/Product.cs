namespace KataCalculator.Products
{
    public class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public decimal BasePrice { get; set; }

        public Product(string name, int UPC, decimal Price)
        {
            Name = name;
            this.UPC = UPC;
            BasePrice = Price;
        }
    }
}
