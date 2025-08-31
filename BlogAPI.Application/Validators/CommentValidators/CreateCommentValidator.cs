// CreateCommentValidator.cs
using FluentValidation;
using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Validators.CommentValidators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Comment content is required")
                .Length(1, 1000).WithMessage("Comment must be between 1 and 1000 characters");
                
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("Post is required")
                .GreaterThan(0).WithMessage("Post ID must be greater than 0");
                
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required")
                .GreaterThan(0).WithMessage("User ID must be greater than 0");
        }
    }
}