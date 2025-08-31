
// UpdatePostValidator.cs
using FluentValidation;
using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Validators.PostValidators
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostValidator()
        {
            RuleFor(x => x.Title)
                .Length(3, 200).WithMessage("Title must be between 3 and 200 characters")
                .When(x => !string.IsNullOrEmpty(x.Title));
                
            RuleFor(x => x.Content)
                .MinimumLength(10).WithMessage("Content must be at least 10 characters")
                .MaximumLength(5000).WithMessage("Content cannot exceed 5000 characters")
                .When(x => !string.IsNullOrEmpty(x.Content));
        }
    }
}