using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }

        public ProductViewModel()
        { 
            Products = ProductRepository.GetAll();
        }

        public void GetAll()
        {
            List<Product> list=Products.Select(prod=>prod).ToList();
        }

    }
}
