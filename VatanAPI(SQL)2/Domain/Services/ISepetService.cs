using System.Collections.Generic;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Services.Communication;

namespace VatanAPI.Domain.Services
{
    public interface ISepetService
    {
        Task<IEnumerable<Sepet>> ListAsync();
        Task<SepetResponse> SaveAsync(Sepet sepet);
        Task<SepetResponse> UpdateAsync(int id, Sepet sepet);
        Task<SepetResponse> DeleteAsync(int id);
    }
}

