using Microsoft.AspNetCore.Mvc;
using BlogAPI.Application.Interfaces;
using BlogAPI.Application.DTOs;

namespace BlogAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            var userDto = await _userService.CreateAsync(createUserDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
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