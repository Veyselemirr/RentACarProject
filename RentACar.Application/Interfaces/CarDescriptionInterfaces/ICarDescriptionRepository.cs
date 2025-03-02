using RentACarDomain.Entities;

namespace RentACar.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        Task<CarDescription> GetCarDescriptionByCarIdAsync(int id);
    }
}
