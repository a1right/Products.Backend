using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Interfaces;
using Products.Domain;

namespace Products.Application.EventLogs.Commands.DeleteEventLog
{
    public class DeleteEventLogCommandHandler : IRequestHandler<DeleteEventLogCommand>
    {
        private readonly IProductsDbContext _context;
        public DeleteEventLogCommandHandler(IProductsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEventLogCommand request, CancellationToken cancellationToken)
        {
            var eventLog = await _context.EventLogs.FirstOrDefaultAsync(e => e.Id == request.Id);
            if (eventLog == null)
                throw new NotFoundException(nameof(EventLog), request.Id);
            _context.EventLogs.Remove(eventLog);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
