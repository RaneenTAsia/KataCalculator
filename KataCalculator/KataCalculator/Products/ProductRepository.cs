namespace KataCalculator.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _productsList =
            new List<Product>
            {
              new Product("Flag KeyChan",39846,20.25M),
              new Product("Map Hoodie",2637458,129.39M)
            };

        #region GetAll Method
        public List<Product> GetAll()
        {
            return _productsList;
        }
        #endregion
    }

}
