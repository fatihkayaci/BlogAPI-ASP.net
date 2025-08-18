using BlogAPI.Application.Interfaces;
using BlogAPI.Application.DTOs;
using BlogAPI.Domain.Entities;

namespace BlogAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            }).ToList();
            return userDtos;
        }
        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
            return userDto;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);
            var user = new User
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            var createdUser = await _userRepository.CreateAsync(user);

            var userDto = new UserDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email,
                CreatedAt = createdUser.CreatedAt
            };
            
            return userDto;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var delete = await _userRepository.DeleteAsync(id);
            return delete;
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null) return false;

            existingUser.Username = updateUserDto.Username ?? existingUser.Username;
            existingUser.Email = updateUserDto.Email ?? existingUser.Email;
            if (!string.IsNullOrEmpty(updateUserDto.Password))
            {
                existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUserDto.Password);
            }
            existingUser.UpdatedAt = DateTime.UtcNow;  // Güncelleme zamanı
            
            var result = await _userRepository.UpdateAsync(existingUser);
            return result;
        }
        
    }
}