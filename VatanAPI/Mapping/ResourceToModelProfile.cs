using AutoMapper;
using VatanAPI.Domain.Models;
using VatanAPI.Resources;

namespace VatanAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}