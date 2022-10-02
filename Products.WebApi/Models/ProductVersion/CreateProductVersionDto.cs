using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Application.ProductVersions.Commands.CreateProductVersion;
using Products.Domain;

namespace Products.WebApi.Models.ProductVersion
{
    public class CreateProductVersionDto : IMapWith<CreateProductVersionCommand>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatingDate { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductVersionDto, CreateProductVersionCommand>()
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
