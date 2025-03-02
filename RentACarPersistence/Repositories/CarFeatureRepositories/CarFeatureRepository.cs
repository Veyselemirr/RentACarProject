using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACarDomain.Entities;
using RentACarPersistence.Context;

namespace RentACar.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly RentACarContext _context;

        public CarFeatureRepository(RentACarContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values =_context.CarFeatures.Where(x=>x.CarFeatureID==id).FirstOrDefault();
            values.Available= false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public async Task CreateCarFeatureByCarIdAsync(CarFeature carFeature)
        {
            await _context.CarFeatures.AddAsync(carFeature);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarIdAsync(int carId)
        {
            return await _context.CarFeatures.Include(x => x.Feature).Where(x => x.CarID == carId).ToListAsync();
        }
    }
}
