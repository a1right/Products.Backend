using MediatR;

namespace Products.Application.EventLogs.Commands.DeleteEventLog
{
    public class DeleteEventLogCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
