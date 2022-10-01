
using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;

namespace Products.Application.Products.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(dto => dto.Id, options => options
                    .MapFrom(prod => prod.Id))
                .ForMember(dto => dto.Name, options => options
                    .MapFrom(prod => prod.Name))
                .ForMember(dto => dto.Description, options => options
                    .MapFrom(prod => prod.Description));
        }
    }
}
