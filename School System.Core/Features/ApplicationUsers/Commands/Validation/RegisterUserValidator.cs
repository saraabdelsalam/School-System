using FluentValidation;
using School_System.Core.Features.ApplicationUsers.Commands.Models;

namespace School_System.Core.Features.ApplicationUsers.Commands.Validation
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        #region Constructors

        public RegisterUserValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            
        }
        #endregion
        #region Methods
        public void ApplyValidationRules()
        {
            RuleFor(u => u.FullName).NotNull().WithMessage("Full Name Field Must Have Valid Values")
                                   .NotEmpty().WithMessage("Full Name Field is Blank")
                                   .MaximumLength(150).WithMessage("Full Name Length Can't Exceed 150 Letter");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Field Must Have Value")
                                 .NotNull().WithMessage("Email Field Must Have A Valid Value");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Field Can't Be Empty")
                                    .NotNull().WithMessage("Password Filed Must Have Valid Value")
                                    .MinimumLength(6).WithMessage("Pasword Minimum Length is 6")
                                    .MaximumLength(20).WithMessage("Password Maximum Length is 20");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password Should be the same");
        }
        public void ApplyCustomValidationRules()
        {

        }
        #endregion
    }
}
