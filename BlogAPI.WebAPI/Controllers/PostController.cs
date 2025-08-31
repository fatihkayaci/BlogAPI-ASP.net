using Microsoft.AspNetCore.Mvc;
using BlogAPI.Application.Interfaces;
using BlogAPI.Application.DTOs;
using FluentValidation;

namespace BlogAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : GenericController<PostDto, CreatePostDto, UpdatePostDto>
    {
        public PostController(
            IPostService postService,
            IValidator<CreatePostDto> createValidator,
            IValidator<UpdatePostDto> updateValidator):base(postService, createValidator, updateValidator)
        {
        }
        protected override object GetItemId(PostDto item)
        {
            return item.Id;
        }
    }
}