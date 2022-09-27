using System;
using MediatR;
using Products.Application.Interfaces;

namespace Products.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        private readonly IProductsDbContext _productsDbContext;
        public CreateProductCommand(IProductsDbContext productsDbContext, string name, string? description)
        {
            _productsDbContext = productsDbContext;
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
