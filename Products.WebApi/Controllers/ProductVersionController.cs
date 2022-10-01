using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Interfaces;
using Products.Application.ProductVersions.Queries.GetAllProductVersionList;

namespace Products.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductVersionController : BaseController
    {
        private readonly IProductsDbContext _context;
        private readonly IMediator _mediator;

        public ProductVersionController(IProductsDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<ProductVersionsListVM>> GetAll()
        {
            var request = new GetAllProductVersionListQuerry();
            var result = await _mediator.Send<ProductVersionsListVM>(request);
            return Ok(result);
        }
    }
}
