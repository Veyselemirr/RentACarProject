﻿using MediatR;
using RentACar.Application.Features.Mediator.Commands.FeatureCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FeatureHandlers;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
{

    private readonly IRepository<Feature> _repository;

    public CreateFeatureCommandHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Feature
        {
            Name = request.Name,
        });
    }
}


  


