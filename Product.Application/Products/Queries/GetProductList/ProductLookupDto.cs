using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .ForMember(dto => dto.Id, opt => opt.MapFrom(prod => prod.Id))
                .ForMember(dto => dto.Name, opt => opt
                    .MapFrom(prod => prod.Name))
                .ForMember(dto => dto.Description, opt => opt
                    .MapFrom(prod => prod.Description));
        }
    }
}
