using System.Collections.Generic;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Services.Communication;

namespace VatanAPI.Domain.Services
{
    public interface ISiparisService
    {
        Task<IEnumerable<Siparis>> ListAsync();
        Task<SiparisResponse> SaveAsync(Siparis siparis);
        Task<SiparisResponse> UpdateAsync(int id, Siparis siparis);
        Task<SiparisResponse> DeleteAsync(int id);
    }
}

