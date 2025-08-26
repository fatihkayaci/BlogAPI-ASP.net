using BlogAPI.Application.Interfaces;
using BlogAPI.Application.DTOs;
using BlogAPI.Domain.Entities;
using AutoMapper;
using BlogAPI.Application.Exceptions;

namespace BlogAPI.Application.Services
{
    public class UserService : BaseService<User, UserDto, CreateUserDto, UpdateUserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }

        public override async Task<UserDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new ValidationException("Email address is already in use");
                
            var user = _mapper.Map<User>(dto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            user.CreatedAt = DateTime.UtcNow;
            
            var createdUser = await _repository.CreateAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public override async Task<bool> UpdateAsync(int id, UpdateUserDto dto, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null) 
                throw new NotFoundException("User", id);

            if (!string.IsNullOrEmpty(dto.Username))
                existingUser.Username = dto.Username;

            if (!string.IsNullOrEmpty(dto.Email))
                existingUser.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.Password))
                existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            existingUser.UpdatedAt = DateTime.UtcNow;

            return await _userRepository.UpdateAsync(existingUser);
        }
    }
}