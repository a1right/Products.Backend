
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Application.Products.Queries.GetProductList;

namespace Products.Application.Products.Queries.GetProductListFilteredByName
{
    public class GetProductListFilteredByNameQuerryHandler : IRequestHandler<GetProductListFilteredByNameQuerry, ProductListVm>
    {
        private readonly IProductsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        public GetProductListFilteredByNameQuerryHandler(IProductsDbContext context, IMapper mapper, IServiceProvider serviceProvider)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public async Task<ProductListVm> Handle(GetProductListFilteredByNameQuerry request,
            CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                .Where(p => p.Name.Contains(request.NamePartial))
                .ToListAsync(cancellationToken);
            return new ProductListVm() { Products = products };
        }
    }
}
