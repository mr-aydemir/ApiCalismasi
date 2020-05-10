using AutoMapper;
using VatanAPI.Domain.Models;
using VatanAPI.Resources;
using VatanAPI.Controllers.Resources;
using VatanAPI.Core.Models;

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