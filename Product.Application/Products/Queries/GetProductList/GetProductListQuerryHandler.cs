
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;

namespace Products.Application.Products.Queries.GetProductList
{
    public class GetProductListQuerryHandler : IRequestHandler<GetProductListQuerry, ProductListVm>
    {
        private readonly IProductsDbContext _context;
        private readonly IMapper _mapper;
        public GetProductListQuerryHandler(IProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetProductListQuerry request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProductListVm() { Products = products };
        }
    }
}
