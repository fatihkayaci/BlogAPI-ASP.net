using Microsoft.AspNetCore.Mvc;
using BlogAPI.Application.Interfaces;
using BlogAPI.Application.DTOs;
using FluentValidation;

namespace BlogAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserDto> _createValidator;
        private readonly IValidator<UpdateUserDto> _updateValidator;

        public UserController(IUserService userService,
        IValidator<CreateUserDto> createValidator,
        IValidator<UpdateUserDto> updateValidator)
        {
            _userService = userService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto?>> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createUserDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var userDto = await _userService.CreateAsync(createUserDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateUserDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await _userService.UpdateAsync(id, updateUserDto);
            if (!result) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result) return NotFound(); 
            return Ok(result);
        }
    }
}