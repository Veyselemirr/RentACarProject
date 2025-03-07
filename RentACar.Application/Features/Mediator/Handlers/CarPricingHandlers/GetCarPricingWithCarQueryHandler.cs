﻿using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;
using RentACar.Application.Interfaces.CarPricingInterface;

namespace RentACar.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
{
    private readonly ICarPricingRepository _repository;
    public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
    {
        _repository=repository;
    }
    public  async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
    {
        var values =  _repository.GetCarPricingWithCars();
        return values.Select(x => new GetCarPricingWithCarQueryResult
        {
            CarID = x.CarID,
            Amount=x.Amount,
            Brand=x.Car.Brand.Name,
            CarPricingId=x.CarPricingID,
            CoverImageUrl=x.Car.CoverImageUrl,
            Model=x.Car.Model
            
        }).ToList();
    }
}
