using AutoMapper;
using VatanAPI.Controllers.Resources;
using VatanAPI.Core.Models;
using VatanAPI.Domain.Models;
using VatanAPI.Resources;

namespace VatanAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<UserCredentialsResource, User>();
        }
    }
}