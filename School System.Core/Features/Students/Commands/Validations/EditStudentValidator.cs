﻿using FluentValidation;
using School_System.Core.Features.Students.Commands.Models;
using School_System.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        public EditStudentValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                            .NotEmpty().WithMessage("Name Can't be blank")
                            .NotNull().WithMessage("Name Must have value")
                            .MaximumLength(100).WithMessage("Name maximum Length is 100 Letter");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address Can't be blank")
                .NotNull().WithMessage("Address Must have value")
                .MaximumLength(100).WithMessage("Address maximum Length is 100 Letter");

        }

        public void ApplyCustomValidationsRules()
        {
        }

    }
}
