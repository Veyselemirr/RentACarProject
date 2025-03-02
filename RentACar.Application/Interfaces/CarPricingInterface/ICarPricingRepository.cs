using RentACar.Application.InterfaceDtos;
using RentACarDomain.Entities;

namespace RentACar.Application.Interfaces.CarPricingInterface;

public interface ICarPricingRepository
{
    List<CarPricing> GetCarPricingWithCars();
    List<CarPricingInterfaceDto> GetCarPricingWithTimePeriod();

}
