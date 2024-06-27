using CarWorkshop.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;
        public EditCarWorkshopCommandHandler(ICarWorkshopRepository repository, IUserContext userContext) 
        {
            _carWorkshopRepository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var dto = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);
            
            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (dto.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

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
