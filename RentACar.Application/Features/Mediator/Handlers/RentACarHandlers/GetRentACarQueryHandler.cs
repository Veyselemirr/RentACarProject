﻿using MediatR;
using RentACar.Application.Features.Mediator.Queries.RentACarQueries;
using RentACar.Application.Features.Mediator.Results.RentACarResults;
using RentACar.Application.Interfaces.RentACarInterfaces;

namespace RentACar.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);
            var results = values.Select(y => new GetRentACarQueryResult
            {
                CarID = y.CarID,
                Brand = y.Car.Brand.Name,
                Model = y.Car.Model,
                CoverImageUrl = y.Car.CoverImageUrl
            }).ToList();
            return results;
        }
    }
}
