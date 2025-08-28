using BlogAPI.Application.Interfaces;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User> ,IUserRepository
    {        
        public UserRepository(BlogDbContext context) : base(context)
        {}
        
        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _dbSet.FirstOrDefaultAsync(e => e.Email == email);
            return user;
        }

    }
}