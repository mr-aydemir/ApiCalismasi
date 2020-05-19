using System.Collections.Generic;
using System.Threading.Tasks;
using VatanAPI.Core.Models;
using VatanAPI.Core.Services.Communication;

namespace VatanAPI.Core.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles);
        Task<User> FindByEmailAsync(string email); 
        Task<IEnumerable<User>> ListAsync();
        Task<CreateUserResponse> DeleteAsync(int id);
        Task<CreateUserResponse> UpdateAsync(int id, User user);
    }
}