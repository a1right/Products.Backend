
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.ProductVersions.Queries.GetProductVersionDetails
{
    public class ProductVersionDetailsQuerryHandler : IRequestHandler<ProductVersionDetailsQuerry, ProductVersionDetailsVM>
    {
        private readonly IProductsDbContext _context;
        private readonly IMapper _mapper;
        public ProductVersionDetailsQuerryHandler(IProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVersionDetailsVM> Handle(ProductVersionDetailsQuerry request, CancellationToken cancellationToken)
        {
            var productVersion = await _context.ProductVersions.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if(productVersion == null)
                throw new NotFoundException(nameof(ProductVersion), request.Id);
            return _mapper.Map<ProductVersionDetailsVM>(productVersion);
        }
    }
}
