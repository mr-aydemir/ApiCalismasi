using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Services;
using VatanAPI.Resources;

namespace VatanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ImageResource>> ListAsync()//GetAllSync ile aynı kodlar.
        {
            var images = await _imageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageResource>>(images);
            return resources;
        }
    }
}