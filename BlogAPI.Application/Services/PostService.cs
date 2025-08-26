using BlogAPI.Application.Interfaces;
using BlogAPI.Application.DTOs;
using BlogAPI.Domain.Entities;
using AutoMapper;

namespace BlogAPI.Application.Services
{
    public class PostService :BaseService<Post, PostDto, CreatePostDto, UpdatePostDto>, IPostService
    {
        private readonly IPostRepository _postRepository;
        
        public PostService(IPostRepository postRepository, IMapper mapper)
        : base(postRepository, mapper)
        {
            _postRepository = postRepository;
        }
        public override async Task<bool> UpdateAsync(int id, UpdatePostDto dto, CancellationToken cancellationToken = default)
        {
            var existingPost = await _postRepository.GetByIdAsync(id);
            if (existingPost == null) return false;

            if (!string.IsNullOrEmpty(dto.Title))
                existingPost.Title = dto.Title;

            if (!string.IsNullOrEmpty(dto.Content))
                existingPost.Content = dto.Content;

            existingPost.UpdatedAt = DateTime.UtcNow;
            
            return await _postRepository.UpdateAsync(existingPost);
        }
        public async Task<IEnumerable<PostDto>> GetPostsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var posts = await _postRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<IEnumerable<PostDto>> SearchPostsAsync(string searchTerm, CancellationToken cancellationToken = default)
        {
            var posts = await _postRepository.SearchAsync(searchTerm);
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        
    }
}