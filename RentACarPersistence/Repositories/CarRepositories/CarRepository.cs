using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACarDomain.Entities;
using RentACarPersistence.Context;

namespace RentACarPersistence.Repositories.CarRepositories;

public class CarRepository : ICarRepository
{
    private readonly RentACarContext _context;

    public CarRepository(RentACarContext context)
    {
        _context = context;
    }

    public List<Car> GetCarsListWithBrands()
    {
        var values = _context.Cars.Include(x=>x.Brand).ToList();       
        return  values;  
    }


    public List<Car> GetLast5CarsWithBrands()
    {
        var values=_context.Cars.Include(x=>x.Brand).OrderByDescending(x=>x.CarID).Take(5).ToList();
        return values;
    }
}
