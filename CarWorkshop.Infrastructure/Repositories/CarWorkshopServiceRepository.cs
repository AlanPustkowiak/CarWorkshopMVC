using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopServiceRepository : ICarWorkshopServiceRepository
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopServiceRepository(CarWorkshopDbContext context)
        {
            _context = context;
        }

        public async Task Create(CarWorkshopService service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }
    }
}
