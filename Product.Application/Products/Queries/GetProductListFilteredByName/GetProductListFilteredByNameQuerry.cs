
using MediatR;
using Products.Application.Products.Queries.GetProductList;

namespace Products.Application.Products.Queries.GetProductListFilteredByName
{
    public class GetProductListFilteredByNameQuerry : IRequest<ProductListVm>
    {
        public string? NamePartial { get; set; }
    }
}
