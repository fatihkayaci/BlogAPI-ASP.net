using BlogAPI.Domain.Entities;
namespace BlogAPI.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}