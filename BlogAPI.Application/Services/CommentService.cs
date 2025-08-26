using BlogAPI.Application.Interfaces;
using BlogAPI.Application.DTOs;
using BlogAPI.Domain.Entities;
using AutoMapper;

namespace BlogAPI.Application.Services
{
    public class CommentService : BaseService<Comment, CommentDto, CreateCommentDto, UpdateCommentDto>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        : base(commentRepository, mapper)
        {
            _commentRepository = commentRepository;
        }
        public override async Task<bool> UpdateAsync(int id, UpdateCommentDto dto, CancellationToken cancellationToken = default)
        {
            var existingComment = await _commentRepository.GetByIdAsync(id);
            if (existingComment == null) return false;

            if (!string.IsNullOrEmpty(dto.Content))
                existingComment.Content = dto.Content;

            existingComment.UpdatedAt = DateTime.UtcNow;
            
            return await _commentRepository.UpdateAsync(existingComment);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int postId, CancellationToken cancellationToken = default)
        {
            var comments = await _commentRepository.GetByPostIdAsync(postId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var comments = await _commentRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

    }
}