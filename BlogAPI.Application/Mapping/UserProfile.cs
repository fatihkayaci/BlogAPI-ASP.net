using AutoMapper;
using BlogAPI.Domain.Entities;
using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Entity -> DTO (Response için)
            CreateMap<User, UserDto>();
            
            // CreateDTO -> Entity  
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Service'te handle edeceğiz
                
            // UpdateDTO -> Entity
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}