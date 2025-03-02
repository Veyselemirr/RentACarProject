using RentACarDomain.Entities;

namespace RentACar.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeaturesByCarIdAsync(int carId);
        void ChangeCarFeatureAvailableToFalse(int id);
        void ChangeCarFeatureAvailableToTrue(int id);
        Task CreateCarFeatureByCarIdAsync(CarFeature carFeature);
    }
}
