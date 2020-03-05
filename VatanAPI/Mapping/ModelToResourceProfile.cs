using AutoMapper;
using VatanAPI.Domain.Models;
using VatanAPI.Extensions;
using VatanAPI.Resources;


namespace VatanAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
            CreateMap<Outstanding, OutstandingResource>();
        }
    }
}
