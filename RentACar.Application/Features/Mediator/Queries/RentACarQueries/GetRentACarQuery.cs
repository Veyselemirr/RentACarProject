using MediatR;
using RentACar.Application.Features.Mediator.Results.RentACarResults;

namespace RentACar.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationID { get; set; }
        public bool Available { get; set; }
    }
}
