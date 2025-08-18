using BlogAPI.Domain.Entities;
namespace BlogAPI.Application.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment?> GetByIdAsync(int id);
        Task<List<Comment>> GetByPostIdAsync(int postId);
        Task<List<Comment>> GetByUserIdAsync (int userId);
        Task<Comment> CreateAsync(Comment comment);
        Task<bool> UpdateAsync(Comment comment);
        Task<bool> DeleteAsync(int id);
    }
}