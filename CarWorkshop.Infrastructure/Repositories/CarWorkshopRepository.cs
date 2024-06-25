using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    internal class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopRepository(CarWorkshopDbContext context)
        {
            _context = context;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            await _context.CarWorkshops.AddAsync(carWorkshop);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
        {
            return await _context.CarWorkshops.ToListAsync();
        }

        public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
        {
            return await _context.CarWorkshops.FirstAsync(c => c.EncodedName == encodedName);
        }

        public async Task<Domain.Entities.CarWorkshop?> GetByName(string name)
        {
            return await _context.CarWorkshops.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public Task Update(Domain.Entities.CarWorkshop carWorkshop)
        {
            return _context.SaveChangesAsync();
        }
    }
}
