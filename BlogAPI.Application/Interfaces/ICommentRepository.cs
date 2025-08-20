using BlogAPI.Domain.Entities;
namespace BlogAPI.Application.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByPostIdAsync(int postId);
        Task<IEnumerable<Comment>> GetByUserIdAsync (int userId);
    }
}