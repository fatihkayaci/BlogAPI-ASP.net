using BlogAPI.Application.DTOs;
using BlogAPI.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : GenericController<CommentDto, CreateCommentDto, UpdateCommentDto>
    {
        public CommentController
        (
            ICommentService commentService,
            IValidator<CreateCommentDto> createValidator,
            IValidator<UpdateCommentDto> updateValidator
        ): base(commentService, createValidator, updateValidator)
        {}
        protected override object GetItemId(CommentDto item)
        {
            return item.Id;
        }
    }
}