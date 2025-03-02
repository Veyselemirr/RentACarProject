﻿using MediatR;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.FeatureQueries;

public class GetFeatureByIdQuery:IRequest<GetFeatureByIdQueryResult>
{
    public GetFeatureByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
