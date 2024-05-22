
using FluentValidation;
using School_System.Core.Features.Departments.Commands.Models;

namespace School_System.Core.Features.Departments.Commands.Validations
{
    public class EditDepartmentValidator : AbstractValidator<EditDepartmentCommand>
    {
        public EditDepartmentValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.id)
                 .NotEmpty().WithMessage("Id Can't be blank")
                 .NotNull().WithMessage("Id Must have value");
        }
        public void ApplyCustomValidationsRules() { }

    }
}
