﻿using MediatR;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Features.Mediator.Queries.FeatureQueries;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    private readonly IRepository<Feature> _repository;

    public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        return new GetFeatureByIdQueryResult
        {
            FeatureID= values.FeatureID,
            Name = values.Name,
        };
    }
}
