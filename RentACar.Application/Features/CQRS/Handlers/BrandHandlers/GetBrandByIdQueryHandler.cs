﻿using RentACar.Application.Features.CQRS.Queries.AboutQueries;
using RentACar.Application.Features.CQRS.Queries.BrandQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandByIdQueryHandler
{
    private readonly IRepository<Brand> _repository;

    public GetBrandByIdQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }
    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetBrandByIdQueryResult
        {
           BrandID = values.BrandID,
           Name=values.Name,
        };
    }
}
