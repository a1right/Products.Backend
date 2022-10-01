using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;

namespace Products.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsVM : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVM>()
                .ForMember(vm => vm.Id, options => options
                    .MapFrom(prod => prod.Id))
                .ForMember(vm => vm.Name, options => options
                    .MapFrom(prod => prod.Name))
                .ForMember(vm => vm.Description, options => options
                    .MapFrom(prod => prod.Description));
        }
    }
}
