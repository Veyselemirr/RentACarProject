﻿using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers;

public class UpdateBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;

    public UpdateBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateBrandCommand command)
    {
        var values = await _repository.GetByIdAsync(command.BrandID);
        values.Name = command.Name;
        await _repository.UpdateAsync(values);
    }
}
