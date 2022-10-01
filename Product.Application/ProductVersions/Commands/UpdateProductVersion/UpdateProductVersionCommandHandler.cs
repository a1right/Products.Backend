
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.ProductVersions.Commands.UpdateProductVersion
{
    public class UpdateProductVersionCommandHandler : IRequestHandler<UpdateProductVersionCommand>
    {
        private readonly IProductsDbContext _context;
        public UpdateProductVersionCommandHandler(IProductsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductVersionCommand request, CancellationToken cancellationToken)
        {
            var productVersion =
                await _context.ProductVersions.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (productVersion == null)
                throw new NotFoundException(nameof(ProductVersion), request.Id);
            productVersion.ProductId = request.ProductId;
            productVersion.Name = request.Name;
            productVersion.Description = request.Description;
            productVersion.CreatingDate = request.CreatingDate;
            productVersion.Width = request.Width;
            productVersion.Height = request.Height;
            productVersion.Length = request.Length;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
