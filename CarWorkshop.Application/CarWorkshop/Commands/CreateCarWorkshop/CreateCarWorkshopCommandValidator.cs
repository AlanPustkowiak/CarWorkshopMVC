using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required").Length(3, 20).WithMessage("Name must be between 3 and 20 characters").Custom((value, context) =>
            {
                var carWorkshop = repository.GetByName(value).Result;
                if (carWorkshop != null)
                {
                    context.AddFailure("Name", "Name already exists");
                }
            });
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Phone number is required").Length(8, 12).WithMessage("Phone number must be between 8 and 12 characters");
        }
    }
}
