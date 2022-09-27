using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Products.Queries.GetProductList
{
    public class ProductListVM
    {
        public IList<ProductLookupDto> Products { get; set; }
    }
}
