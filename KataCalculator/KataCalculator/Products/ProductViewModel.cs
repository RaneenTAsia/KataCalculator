namespace KataCalculator.Products
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }

        public ProductViewModel()
        {
            Products = ProductRepository.GetAll();
        }
    }
}
