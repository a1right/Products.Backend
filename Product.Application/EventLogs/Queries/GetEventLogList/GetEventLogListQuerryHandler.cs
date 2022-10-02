
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;

namespace Products.Application.EventLogs.Queries.GetEventLogList
{
    public class GetEventLogListQuerryHandler : IRequestHandler<GetEventLogListQuerry, EventLogListVM>
    {
        private readonly IProductsDbContext _context;
        private readonly IMapper _mapper;
        public GetEventLogListQuerryHandler(IProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventLogListVM> Handle(GetEventLogListQuerry request, CancellationToken cancellationToken)
        {
            var eventLogs = await _context.EventLogs
                .ProjectTo<EventLogLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new EventLogListVM() { EventLogs = eventLogs };
        }
    }
}
