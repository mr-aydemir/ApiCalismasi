using AutoMapper;
using VatanAPI.Domain.Models;
using VatanAPI.Extensions;
using VatanAPI.Resources;
using VatanAPI.Core.Models;
using VatanAPI.Controllers.Resources;
using VatanAPI.Core.Security.Tokens;
using System.Linq;

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
            CreateMap<User, UserResource>()
               .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(ur => ur.Role.Name)));

            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
        }
    }
}
