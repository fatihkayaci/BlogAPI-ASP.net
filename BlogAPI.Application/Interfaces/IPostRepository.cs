using BlogAPI.Domain.Entities;
namespace BlogAPI.Application.Interfaces
{
    public interface IPostRepository
    {
        Task<Post?> GetByIdAsync(int id);
        Task<List<Post>> GetByUserIdAsync(int userId);
        Task<Post> CreateAsync(Post post);
        Task<bool> UpdateAsync(Post post);
        Task<bool> DeleteAsync(int id);
        Task<List<Post>> GetAllAsync();
    }
}