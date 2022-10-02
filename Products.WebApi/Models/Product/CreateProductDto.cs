using AutoMapper;
using Products.Application.Products.Commands.CreateProduct;
using Products.Application.Common.Mappings;

namespace Products.WebApi.Models.Product
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(command => command.Name, opt => opt
                    .MapFrom(dto => dto.Name))
                .ForMember(command => command.Description, opt => opt
                    .MapFrom(dto => dto.Description));
        }
    }
}
