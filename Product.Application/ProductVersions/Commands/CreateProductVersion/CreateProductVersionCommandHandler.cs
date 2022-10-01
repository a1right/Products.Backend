
using MediatR;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.ProductVersions.Commands.CreateProductVersion
{
    public class CreateProductVersionCommandHandler : IRequestHandler<CreateProductVersionCommand, Guid>
    {
        private readonly IProductsDbContext _context;
        public CreateProductVersionCommandHandler(IProductsDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductVersionCommand request, CancellationToken cancellationToken)
        {
            var productVersion = new ProductVersion()
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                Name = request.Name,
                Description = request.Description,
                CreatingDate = request.CreatingDate,
                Width = request.Width,
                Height = request.Height,
                Length = request.Length,
            };
            await _context.ProductVersions.AddAsync(productVersion, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return productVersion.Id;
        }
    }
    
}
