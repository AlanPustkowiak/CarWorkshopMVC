using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.CarWorkshops.Any())
                {
                    var fordAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Ford ASO",
                        Description = "Autoryzowany serwis Ford",
                        About = "Najlepszy serwis Ford w okolicy",
                        ContactDetails = new()
                        {
                            City = "Poznań",
                            Street = "Pakosławska 69",
                            PostalCode = "60-101",
                            PhoneNumber = "123456789"
                        }
                    };
                    fordAso.SetEncodeName();
                    _context.CarWorkshops.Add(fordAso);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
