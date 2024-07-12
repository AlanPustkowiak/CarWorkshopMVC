using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandValidator : AbstractValidator<CreateCarWorkshopServiceCommand>
    {
        public CreateCarWorkshopServiceCommandValidator() 
        {
            RuleFor(x => x.Description)
                .NotEmpty().NotNull();

            RuleFor(x => x.Cost)
                .NotEmpty().NotNull();

            RuleFor(x => x.CarWorkshopEncodedName).NotEmpty().NotNull();
        }
    }
}
