using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Repositories;
using VatanAPI.Persistence.Contexts;

namespace VatanAPI.Persistence.Repositories
{
    public class SepetRepository : BaseRepository, ISepetRepository
    {

        public SepetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Sepet>> ListAsync()
        {
            return await _context.Sepet.ToListAsync();
        }
        public async Task AddAsync(Sepet sepet)
        {
            await _context.Sepet.AddAsync(sepet);
        }
        public async Task<Sepet> FindByIdAsync(int id)
        {
            return await _context.Sepet.FindAsync(id);
        }
        public void Update(Sepet sepet)
        {
            _context.Sepet.Update(sepet);
        }
        public void Remove(Sepet sepet)
        {
            _context.Sepet.Remove(sepet);
        }
    }
}