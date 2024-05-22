
using FluentValidation;
using School_System.Core.Features.Departments.Commands.Models;

namespace School_System.Core.Features.Departments.Commands.Validations
{
    public class AddDepartmentValidator : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.DepartmentName)
                 .NotEmpty().WithMessage("Name Can't be blank")
                 .NotNull().WithMessage("Name Must have value")
                 .MaximumLength(100).WithMessage("Name maximum Length is 100 Letter");
        }
        public void ApplyCustomValidationsRules() { }

    }
}
