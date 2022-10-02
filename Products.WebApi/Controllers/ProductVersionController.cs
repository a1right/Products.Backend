using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Interfaces;
using Products.Application.ProductVersions.Commands.CreateProductVersion;
using Products.Application.ProductVersions.Commands.DeleteProductVersion;
using Products.Application.ProductVersions.Commands.UpdateProductVersion;
using Products.Application.ProductVersions.Queries.GetAllProductVersionList;
using Products.Application.ProductVersions.Queries.GetProductVersionDetails;
using Products.WebApi.Models.ProductVersion;

namespace Products.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductVersionController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductVersionController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ProductVersionsListVm>> GetAll()
        {
            var querry = new GetAllProductVersionListQuerry();
            var result = await Mediator.Send<ProductVersionsListVm>(querry);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVersionDetailsVM>> Get(Guid id)
        {
            var querry = new ProductVersionDetailsQuerry();
            querry.Id = id;
            var result = await Mediator.Send<ProductVersionDetailsVM>(querry);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductVersionDto createProductVersionDto)
        {
            var command = _mapper.Map<CreateProductVersionCommand>(createProductVersionDto);
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductVersionDto updateProductVersionDto)
        {
            var command = _mapper.Map<UpdateProductVersionCommand>(updateProductVersionDto);
            var result = await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductVersionCommand() { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
