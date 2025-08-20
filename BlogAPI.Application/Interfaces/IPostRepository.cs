using BlogAPI.Domain.Entities;
namespace BlogAPI.Application.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<Post>> GetByUserIdAsync(int userId);
    }
}