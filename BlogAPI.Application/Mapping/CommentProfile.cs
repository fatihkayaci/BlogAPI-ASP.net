using AutoMapper;
using BlogAPI.Domain.Entities;
using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            // Entity -> DTO (Response için)
            CreateMap<Comment, CommentDto>();
            
            // CreateDTO -> Entity  
            CreateMap<CreateCommentDto, Comment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
                
            // UpdateDTO -> Entity
            CreateMap<UpdateCommentDto, Comment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}