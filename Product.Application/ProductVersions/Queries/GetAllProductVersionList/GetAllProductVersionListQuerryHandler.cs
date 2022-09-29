using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;

namespace Products.Application.ProductVersions.Queries.GetAllProductVersionList
{
    public class GetAllProductVersionListQuerryHandler : IRequestHandler<GetAllProductVersionListQuerry, ProductVersionsListVM>
    {
        private readonly IProductsDbContext _context;
        private readonly IMapper _mapper;
        public GetAllProductVersionListQuerryHandler(IProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVersionsListVM> Handle(GetAllProductVersionListQuerry request,
            CancellationToken cancellationToken)
        {
            var productVersions = await _context.ProductVersions
                .ProjectTo<ProductVersionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProductVersionsListVM { ProductVersions = productVersions };
        }
    }
}
