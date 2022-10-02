using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using Products.Application.EventLogs.Commands.DeleteEventLog;
using Products.Application.EventLogs.Queries.GetEventLogDetails;
using Products.Application.EventLogs.Queries.GetEventLogList;
using Products.Application.Interfaces;

namespace Products.WebApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class EventLogController : BaseController
    {
        private readonly IProductsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public EventLogController(IProductsDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<EventLogListVM>> GetAll()
        {
            var querry = new GetEventLogListQuerry();
            var result = await _mediator.Send(querry);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var command = new DeleteEventLogCommand() { Id = id }; 
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
