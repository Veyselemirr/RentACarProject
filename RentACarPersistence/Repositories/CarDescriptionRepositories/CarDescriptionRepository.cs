using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarDescriptionInterfaces;
using RentACarDomain.Entities;
using RentACarPersistence.Context;

namespace RentACar.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly RentACarContext _context;

        public CarDescriptionRepository(RentACarContext context)
        {
            _context = context;
        }

        public async Task<CarDescription> GetCarDescriptionByCarIdAsync(int id)
        {
            return await _context.CarDescriptions.FirstOrDefaultAsync(x => x.CarID == id);
        }
    }
}
