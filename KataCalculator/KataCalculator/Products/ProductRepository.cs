using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Products
{
    public partial class ProductRepository
    {
        #region GetAll Method
        public static List<Product> GetAll()
        {
            return new List<Product>
            {
              new Product("Flag KeyChan",39846,20.50M),
              new Product("Map Hoodie",2637458,129.39M)
            };
        }
        #endregion
    }

}
