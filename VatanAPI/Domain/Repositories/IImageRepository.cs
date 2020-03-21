using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;

namespace VatanAPI.Domain.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> ListAsync();
    }
}
