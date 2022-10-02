
using MediatR;
using Products.Application.EventLogs.Queries.GetEventLogList;

namespace Products.Application.EventLogs.Queries.GetEventLogDetails
{
    public class GetEventLogDetailsQuerry : IRequest<EventLogDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
