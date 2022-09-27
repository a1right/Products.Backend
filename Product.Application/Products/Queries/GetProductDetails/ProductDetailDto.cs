using System;
using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;

namespace Products.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailDto : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailDto>()
                .ForMember(dto => dto.Id, opt => opt
                    .MapFrom(prod => prod.Id))
                .ForMember(dto => dto.Name, opt => opt
                    .MapFrom(prod => prod.Name))
                .ForMember(dto => dto.Description, opt => opt
                    .MapFrom(prod => prod.Description));
        }
    }
}
