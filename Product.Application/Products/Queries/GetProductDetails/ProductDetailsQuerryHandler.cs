using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsQuerryHandler : IRequestHandler<GetProductDetailsQuerry, ProductDetailsVM>
    {
        private readonly IProductsDbContext _context;
        private readonly IMapper _mapper;
        public ProductDetailsQuerryHandler(IProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailsVM> Handle(GetProductDetailsQuerry request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);
            return _mapper.Map<ProductDetailsVM>(product);
        }
    }
}
