using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Pole musi być uzupełnione!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Pole musi być uzupełnione!").Length(8, 12).WithMessage("Numer telefonu musi zawierać od 8 do 12 znaków!"); 
        }
    }
}
