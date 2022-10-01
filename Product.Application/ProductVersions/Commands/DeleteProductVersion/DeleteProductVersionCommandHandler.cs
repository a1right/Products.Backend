using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Products.Application.Common.Exceptions;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.ProductVersions.Commands.DeleteProductVersion
{
    public class DeleteProductVersionCommandHandler : IRequestHandler<DeleteProductVersionCommand>
    {
        private readonly IProductsDbContext _context;
        public DeleteProductVersionCommandHandler(IProductsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductVersionCommand request, CancellationToken cancellationToken)
        {
            var productVersion = await _context.ProductVersions.FindAsync(request.Id, cancellationToken);
            if(productVersion == null)
                throw new NotFoundException(nameof(ProductVersion), request.Id);
            _context.ProductVersions.Remove(productVersion);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
