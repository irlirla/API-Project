using FluentValidation;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class HeroValidator : AbstractValidator<Hero>, IHeroValidator
    {
        public HeroValidator()
        {
            RuleFor(x => x.ID)
                .NotNull()
                .GreaterThan(-1)
                .LessThan(int.MaxValue)
                .WithMessage("Please, choose another id!");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(70)
                .WithMessage("Please, try again to enter the Name.");

            RuleFor(x => x.SecondName)
                .NotEmpty()
                .MaximumLength(70)
                .WithMessage("Please, try again to enter the Name.");

            RuleFor(x => x.Fac)
                .NotNull()
                .GreaterThan(0)
                .LessThan(5)
                .WithMessage("Please, choose a Faculty: from 1 to 4.");

            RuleFor(x => x.Army)
                .NotNull()
                .WithMessage("Please, choose a Dumbledore's Army involvement like 0 or 1 (no or yes).");
        }
    }
}
