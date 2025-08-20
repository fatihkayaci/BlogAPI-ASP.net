using BlogAPI.Application.Interfaces;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _context;
        
        public CommentRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return false;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            List<Comment> comments = await _context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetByPostIdAsync(int postId)
        {
            List<Comment> comments = await _context.Comments.Where(p => p.PostId == postId).ToListAsync();
            return comments;
        }

        public async Task<IEnumerable<Comment>> GetByUserIdAsync(int userId)
        {
            List<Comment> comments = await _context.Comments.Where(u => u.UserId == userId).ToListAsync();
            return comments;
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}