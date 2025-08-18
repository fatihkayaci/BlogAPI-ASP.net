using BlogAPI.Application.Interfaces;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;
        
        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Post> CreateAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            
            List<Post> posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post;
        }

        public async Task<List<Post>> GetByUserIdAsync(int userId)
        {
            List<Post> posts = await _context.Posts.Where(u => u.UserId == userId).ToListAsync();
            return posts;
        }

        public async Task<bool> UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}