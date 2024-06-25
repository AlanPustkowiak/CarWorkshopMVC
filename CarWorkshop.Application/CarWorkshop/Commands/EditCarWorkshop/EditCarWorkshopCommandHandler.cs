using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        public EditCarWorkshopCommandHandler(ICarWorkshopRepository repository) 
        {
            _carWorkshopRepository = repository;
        }
        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var dto = await _carWorkshopRepository.GetByEncodedName(request.EncodedName);
            
            dto.Description = request.Description;
            dto.About = request.About;
            dto.ContactDetails.City = request.City;
            dto.ContactDetails.PhoneNumber = request.PhoneNumber;
            dto.ContactDetails.PostalCode = request.PostalCode;
            dto.ContactDetails.Street = request.Street;

            await _carWorkshopRepository.Update(dto);
            
            return Unit.Value;
        }
    }
}
