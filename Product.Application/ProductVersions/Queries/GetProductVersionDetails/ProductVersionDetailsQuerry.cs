
using MediatR;

namespace Products.Application.ProductVersions.Queries.GetProductVersionDetails
{
    public class ProductVersionDetailsQuerry : IRequest<ProductVersionDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
