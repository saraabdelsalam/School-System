
using FluentValidation;
using School_System.Core.Features.ApplicationUsers.Commands.Models;

namespace School_System.Core.Features.ApplicationUsers.Commands.Validation
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        #region Constructors
        public ChangeUserPasswordValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Can't be empty")
                .NotNull().WithMessage("Id is Required");

            RuleFor(x => x.CurrentPassword)
                 .NotEmpty().WithMessage("CurrentPassword Can't be empty")
                 .NotNull().WithMessage("CurrentPassword is Required");
            RuleFor(x => x.NewPassword)
                 .NotEmpty().WithMessage("NewPassword Can't be empty")
                 .NotNull().WithMessage("NewPassword is Required");
            RuleFor(x => x.ConfirmPassword)
                 .NotNull().WithMessage("ConfirmPassword is Required")
                 .Equal(x => x.NewPassword).WithMessage("Password Is Not Equal ConfirmPassword");

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }

}
