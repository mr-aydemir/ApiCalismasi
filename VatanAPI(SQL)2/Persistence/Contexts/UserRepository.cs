using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Core.Models;
using VatanAPI.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using VatanAPI.Persistence.Contexts;


namespace VatanAPI.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user/*, ERole[] userRoles*/)
        {
            // var roleNames = userRoles.Select(r => r.ToString()).ToList();
            /*var roles = await _context.Roles.Where(r => roleNames.Contains(r.Name)).ToListAsync();

            foreach(var role in roles)
            {
                user.UserRoles.Add(new UserRole { RoleId = role.Id });
            }*/

            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users
                                       .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}