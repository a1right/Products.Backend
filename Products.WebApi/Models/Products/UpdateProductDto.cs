using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Application.Products.Commands.UpdateProduct;

namespace Products.WebApi.Models.Products
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(com => com.Id, opt => opt
                    .MapFrom(dto => dto.Id))
                .ForMember(com => com.Name, opt => opt
                    .MapFrom(dto => dto.Name))
                .ForMember(com => com.Description, opt => opt
                    .MapFrom(dto => dto.Description));
        }
    }
}
