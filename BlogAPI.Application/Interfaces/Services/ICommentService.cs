using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Interfaces
{
    public interface ICommentService : IGenericService<CommentDto, CreateCommentDto, UpdateCommentDto>
    {
        Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int postId, CancellationToken cancellationToken = default);
        Task<IEnumerable<CommentDto>> GetCommentsByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        
    }
}