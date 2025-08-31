// CreatePostValidator.cs
using FluentValidation;
using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Validators.PostValidators
{
    public class CreatePostValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(3, 200).WithMessage("Title must be between 3 and 200 characters");
                
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .MinimumLength(10).WithMessage("Content must be at least 10 characters")
                .MaximumLength(5000).WithMessage("Content cannot exceed 5000 characters");
                
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required")
                .GreaterThan(0).WithMessage("User ID must be greater than 0");
        }
    }
}
