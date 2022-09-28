using System;
using MediatR;
using Products.Domain;

namespace Products.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuerry : IRequest<ProductDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
