using RentACarDomain.Entities;
using System.Linq.Expressions;

namespace RentACar.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
        Task<List<RentaCar>> GetByFilterAsync(Expression<Func<RentaCar, bool>> filter);
    }
}
