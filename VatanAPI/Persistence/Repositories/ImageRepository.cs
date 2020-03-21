using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Repositories;
using VatanAPI.Persistence.Contexts;

namespace VatanAPI.Persistence.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _context.Images.Include(p => p.Product)
                                          .ToListAsync();
        }
    }
}
