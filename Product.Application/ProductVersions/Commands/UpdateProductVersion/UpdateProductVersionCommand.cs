
using MediatR;

namespace Products.Application.ProductVersions.Commands.UpdateProductVersion
{
    public class UpdateProductVersionCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatingDate { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
    }
}
