using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Products.Application.Common.Exceptions;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductsDbContext _context;
        public DeleteProductCommandHandler(IProductsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
