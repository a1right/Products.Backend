using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Application.ProductVersions.Commands.UpdateProductVersion;

namespace Products.WebApi.Models.ProductVersion
{
    public class UpdateProductVersionDto : IMapWith<UpdateProductVersionCommand>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatingDate { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductVersionDto, UpdateProductVersionCommand>()
                .ForMember(command => command.Id, options => options
                    .MapFrom(dto => dto.Id))
                .ForMember(command => command.ProductId, options => options
                    .MapFrom(dto => dto.ProductId))
                .ForMember(command => command.Name, options => options
                    .MapFrom(dto => dto.Name))
                .ForMember(command => command.Description, options => options
                    .MapFrom(dto => dto.Description))
                .ForMember(command => command.CreatingDate, options => options
                    .MapFrom(dto => dto.CreatingDate))
                .ForMember(command => command.Width, options => options
                    .MapFrom(dto => dto.Width))
                .ForMember(command => command.Height, options => options
                    .MapFrom(dto => dto.Height))
                .ForMember(command => command.Length, options => options
                    .MapFrom(dto => dto.Length));
        }
    }
}
