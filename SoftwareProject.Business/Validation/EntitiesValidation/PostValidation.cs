using SoftwareProject.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SoftwareProject.Business.Validation.EntitiesValidation
{
    public abstract class PostValidation :AbstractValidator<PostDto>
    {
        public PostValidation()
        {
            RuleFor(x => x.Content).NotEmpty().When(x => x.ImagePath == null).WithMessage("This fields cannot be empty..!").MaximumLength(140).WithMessage("You cannot use more than 140 character..!");
        }

    }
}
