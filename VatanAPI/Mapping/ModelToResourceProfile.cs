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
                .ForMember(src => src.Marka,
                           opt => opt.MapFrom(src => src.Marka.ToDescriptionString()));
            CreateMap<Image, ImageResource>();
        }
    }
}
