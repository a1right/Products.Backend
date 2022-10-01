
using MediatR;

namespace Products.Application.ProductVersions.Queries.GetProductVersionDetails
{
    public class ProductVersionQuerry : IRequest<ProductVersionDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
