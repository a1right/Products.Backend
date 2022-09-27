using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductsDbContext _context;
        public UpdateProductCommandHandler(IProductsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), product);
            }

            product.Name = request.Name;
            product.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
