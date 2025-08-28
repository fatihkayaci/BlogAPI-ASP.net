using BlogAPI.Application.Interfaces;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {        
        public PostRepository(BlogDbContext context) : base(context)
        {}

        public async Task<IEnumerable<Post>> GetByUserIdAsync(int userId)
        {
            List<Post> posts = await _dbSet.Where(u => u.UserId == userId).ToListAsync();
            return posts;
        }
        
        public async Task<IEnumerable<Post>> SearchAsync(string searchTerm)
        {
            return await _dbSet
                .Where(p => p.Title.Contains(searchTerm) || p.Content.Contains(searchTerm))
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }
    }
}