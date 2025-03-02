using MediatR;
using RentACar.Application.Features.Mediator.Commands.LocationCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Locations.Mediator.Handlers.LocationHandlers;

public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public UpdateSocialMediaCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.LocationID);
        values.Name = request.Name;
        await _repository.UpdateAsync(values);
    }
}