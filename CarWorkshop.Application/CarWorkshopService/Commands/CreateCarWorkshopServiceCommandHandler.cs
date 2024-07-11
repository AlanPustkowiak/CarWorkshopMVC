using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IUserContext _userContext;
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;
        public CreateCarWorkshopServiceCommandHandler(IUserContext userContext, ICarWorkshopRepository carWorkshopRepository, ICarWorkshopServiceRepository carWorkshopServiceRepository)
        {
            _userContext = userContext;
            _carWorkshopRepository = carWorkshopRepository;
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
        }
        public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var dto = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (dto.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Description = request.Description,
                Cost = request.Cost,
                CarWorkshopId = dto.id
            };

            await _carWorkshopServiceRepository.Create(carWorkshopService);

            return Unit.Value;
        }
    
    }
}
