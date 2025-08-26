using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Interfaces
{
    public interface IUserService : IGenericService<UserDto, CreateUserDto, UpdateUserDto>
    {
    }
}