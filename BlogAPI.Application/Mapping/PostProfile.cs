using AutoMapper;
using BlogAPI.Domain.Entities;
using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Mapping
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            // Entity -> DTO (Response için)
            CreateMap<Post, PostDto>();
            
            // CreateDTO -> Entity  
            CreateMap<CreatePostDto, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
                
            // UpdateDTO -> Entity
            CreateMap<UpdatePostDto, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UserId, opt => opt.Ignore()); // UserId değişmesin update'te
        }
    }
}