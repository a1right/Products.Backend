
using MediatR;

namespace Products.Application.ProductVersions.Commands.DeleteProductVersion
{
    public class DeleteProductVersionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
