using FluentValidation;
using BlogAPI.Application.DTOs;

namespace BlogAPI.Application.Validators.UserValidators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Username)
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters")
                .When(x => !string.IsNullOrEmpty(x.Username));
                
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email format is not valid")
                .When(x => !string.IsNullOrEmpty(x.Email));
                
            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .When(x => !string.IsNullOrEmpty(x.Password));
        }
    }
}