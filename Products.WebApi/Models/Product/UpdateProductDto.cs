using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Application.Products.Commands.UpdateProduct;

namespace Products.WebApi.Models.Product
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(command => command.Id, opt => opt
                    .MapFrom(dto => dto.Id))
                .ForMember(command => command.Name, opt => opt
                    .MapFrom(dto => dto.Name))
                .ForMember(command => command.Description, opt => opt
                    .MapFrom(dto => dto.Description));
        }
    }
}
