using System.Collections.Generic;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Services.Communication;

namespace VatanAPI.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}
