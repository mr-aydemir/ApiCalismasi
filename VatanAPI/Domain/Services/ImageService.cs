using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Services;
using VatanAPI.Domain.Repositories;
using VatanAPI.Persistence.Repositories;
using VatanAPI.Domain.Services.Communication;

namespace VatanAPI.Domain.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _imageRepository.ListAsync();
        }
    }
}

