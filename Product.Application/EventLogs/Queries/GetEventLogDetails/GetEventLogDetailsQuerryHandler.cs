
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.EventLogs.Queries.GetEventLogDetails
{
    public class GetEventLogDetailsQuerryHandler : IRequestHandler<GetEventLogDetailsQuerry, EventLogDetailsVM>
    {
        private readonly IProductsDbContext _context;
        private readonly IMapper _mapper;
        public GetEventLogDetailsQuerryHandler(IProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventLogDetailsVM> Handle(GetEventLogDetailsQuerry request,
            CancellationToken cancellationToken)
        {
            var eventLog = await _context.EventLogs.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (eventLog == null)
                throw new NotFoundException(nameof(EventLog), request.Id);
            return _mapper.Map<EventLogDetailsVM>(eventLog);
        }
    }
}
