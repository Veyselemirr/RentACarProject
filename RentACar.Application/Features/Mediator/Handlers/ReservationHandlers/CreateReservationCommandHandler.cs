﻿using MediatR;
using RentACar.Application.Features.Mediator.Commands.ReservationCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.ReservationHandlers;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IRepository<Reservation> _repository;
    public CreateReservationCommandHandler(IRepository<Reservation> repository)
    {
        _repository=repository;
    }
    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Reservation
        {
            Age = request.Age,
            CarID = request.CarID,
            Description = request.Description,
            DropOffLocationID = request.DropOffLocationID,
            DriverLicenseYear = request.DriverLicenseYear,
            Email = request.Email,
            Name = request.Name,
            Phone = request.Phone,
            PickUpLocationID = request.PickUpLocationID,
            Surname = request.Surname,
            Status = "Rezervasyon Alındı",
        });
    }
}
