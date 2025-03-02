using Microsoft.EntityFrameworkCore;
using RentACar.Application.InterfaceDtos;
using RentACar.Application.Interfaces.CarPricingInterface;
using RentACarDomain.Entities;
using RentACarPersistence.Context;

namespace RentACarPersistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly RentACarContext _context;
        public CarPricingRepository(RentACarContext context)
        {
            _context=context;
        }
        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z=>z.PricingID==2).ToList();
            return values;
        }

        public List<CarPricingInterfaceDto> GetCarPricingWithTimePeriod()
        {
            List<CarPricingInterfaceDto> values = new List<CarPricingInterfaceDto>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select CoverImageUrl, Name, Model, CarPricings.CarID, PricingID, Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarID Inner Join Brands On Brands.BrandID = Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([1],[2],[3])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingInterfaceDto carPricing = new CarPricingInterfaceDto()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            CarID = Convert.ToInt32(reader[3]),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader[4]),
                                Convert.ToDecimal(reader[5]),
                                Convert.ToDecimal(reader[6]),
                            }
                        };
                        values.Add(carPricing);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
        }
    }
