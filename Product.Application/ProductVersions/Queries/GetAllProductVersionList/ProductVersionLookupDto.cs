using AutoMapper;
using Products.Domain;
using Products.Application.Common.Mappings;

namespace Products.Application.ProductVersions.Queries.GetAllProductVersionList
{
    public class ProductVersionLookupDto : IMapWith<ProductVersion>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatingDate { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductVersion, ProductVersionLookupDto>()
                .ForMember(dto => dto.Id, options => options
                    .MapFrom(ver => ver.Id))
                .ForMember(dto => dto.ProductId, options => options
                    .MapFrom(ver => ver.ProductId))
                .ForMember(dto => dto.Name, options => options
                    .MapFrom(ver => ver.Name))
                .ForMember(dto => dto.Description, options => options
                    .MapFrom(ver => ver.Description))
                .ForMember(dto => dto.CreatingDate, options => options
                    .MapFrom(ver => ver.CreatingDate))
                .ForMember(dto => dto.Width, options => options
                    .MapFrom(ver => ver.Width))
                .ForMember(dto => dto.Height, options => options
                    .MapFrom(ver => ver.Height))
                .ForMember(dto => dto.Length, options => options
                    .MapFrom(ver => ver.Length));
        }
    }
}
