
using MediatR;

namespace Products.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuerry : IRequest<ProductDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
