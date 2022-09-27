using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Products.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuerry : IRequest<ProductDetailDto>
    {
        public Guid Id { get; set; }
    }
}
