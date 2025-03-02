using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.RentACarInterfaces;
using RentACarDomain.Entities;
using RentACarPersistence.Context;
using System.Linq.Expressions;

namespace RentACar.Persistance.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly RentACarContext _context;

        public RentACarRepository(RentACarContext context)
        {
            _context = context;
        }

        public async Task<List<RentaCar>> GetByFilterAsync(Expression<Func<RentaCar, bool>> filter) 
        {
            var values = await _context.RentACars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
            return values;
        }
    }
}

