using FluentValidation;
using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Validators.CommentValidators
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.Content)
                .Length(1, 1000).WithMessage("Comment must be between 1 and 1000 characters")
                .When(x => !string.IsNullOrEmpty(x.Content));
        }
    }
}