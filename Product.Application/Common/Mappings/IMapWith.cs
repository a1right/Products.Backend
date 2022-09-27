using AutoMapper;
using System.Threading.Tasks;

namespace Products.Application.Common.Mappings
{
    internal interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
