using System.Collections.Generic;

namespace OnlineShop2022.Models
{
    public class ProductViewModel
    {
        public ProductModel Product { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
