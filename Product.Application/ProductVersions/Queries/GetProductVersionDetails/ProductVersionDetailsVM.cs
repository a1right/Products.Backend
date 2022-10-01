using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;

namespace Products.Application.ProductVersions.Queries.GetProductVersionDetails
{
    public class ProductVersionDetailsVM : IMapWith<ProductVersion>
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
            profile.CreateMap<ProductVersion, ProductVersionDetailsVM>()
                .ForMember(vm => vm.Id, options => options
                    .MapFrom(prod => prod.Id))
                .ForMember(vm => vm.ProductId, options => options
                    .MapFrom(prod => prod.ProductId))
                .ForMember(vm => vm.Name, options => options
                    .MapFrom(prod => prod.Name))
                .ForMember(vm => vm.Description, options => options
                    .MapFrom(prod => prod.Description))
                .ForMember(vm => vm.CreatingDate, options => options
                    .MapFrom(prod => prod.CreatingDate))
                .ForMember(vm => vm.Width, options => options
                    .MapFrom(prod => prod.Width))
                .ForMember(vm => vm.Height, options => options
                    .MapFrom(prod => prod.Height))
                .ForMember(vm => vm.Length, options => options
                    .MapFrom(prod => prod.Length));
        }
    }
}
