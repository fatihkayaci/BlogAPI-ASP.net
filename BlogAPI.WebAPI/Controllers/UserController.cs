using Microsoft.AspNetCore.Mvc;
using BlogAPI.Application.Interfaces;
using BlogAPI.Application.DTOs;
using FluentValidation;

namespace BlogAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : GenericController<UserDto, CreateUserDto, UpdateUserDto>
    {
        public UserController(
            IUserService userService,
            IValidator<CreateUserDto> createValidator,
            IValidator<UpdateUserDto> updateValidator):base(userService, createValidator, updateValidator)
        {
        }

        protected override object GetItemId(UserDto item)
        {
            return item.Id;
        }
    }
}