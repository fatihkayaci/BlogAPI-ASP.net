using BlogAPI.Application.Interfaces;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDbContext context) : base(context)
        {}
        public async Task<IEnumerable<Comment>> GetByPostIdAsync(int postId)
        {
            List<Comment> comments = await _dbSet.Where(p => p.PostId == postId).ToListAsync();
            return comments;
        }

        public async Task<IEnumerable<Comment>> GetByUserIdAsync(int userId)
        {
            List<Comment> comments = await _dbSet.Where(u => u.UserId == userId).ToListAsync();
            return comments;
        }

    }
}