using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.EventLogs.Commands.DeleteEventLog;
using Products.Application.EventLogs.Queries.GetEventLogList;
using Products.Application.Interfaces;

namespace Products.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EventLogController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<EventLogListVm>> Get()
        {
            var querry = new GetEventLogListQuerry();
            var result = await Mediator.Send(querry);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var command = new DeleteEventLogCommand() { Id = id }; 
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
