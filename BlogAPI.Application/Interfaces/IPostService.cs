using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Interfaces
{
    public interface IPostService : IGenericService<PostDto, CreatePostDto, UpdatePostDto>
    {
        Task<IEnumerable<PostDto>> GetPostsByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PostDto>> SearchPostsAsync(string searchTerm, CancellationToken cancellationToken = default);
    }
}