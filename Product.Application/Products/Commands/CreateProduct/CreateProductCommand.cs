using System;
using MediatR;
using Products.Application.Interfaces;

namespace Products.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
