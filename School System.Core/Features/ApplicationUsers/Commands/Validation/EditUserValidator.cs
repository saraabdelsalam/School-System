

using FluentValidation;
using School_System.Core.Features.ApplicationUsers.Commands.Models;

namespace School_System.Core.Features.ApplicationUsers.Commands.Validation
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Constructors
        public EditUserValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName Must Have a Value")
                .NotNull().WithMessage("UserName Must Have valid value")
                .MaximumLength(100).WithMessage("Maximum Length is 100 chars");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Field Must Have Value")
                                .NotNull().WithMessage("Email Field Must Have A Valid Value");
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
