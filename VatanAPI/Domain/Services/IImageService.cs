using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;

namespace VatanAPI.Domain.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> ListAsync();
    }
}
