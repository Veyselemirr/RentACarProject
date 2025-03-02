using MediatR;
using RentACar.Application.Features.Mediator.Commands.LocationCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Locations.Mediator.Handlers.LocationHandlers;

public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveLocationCommand>

{
    private readonly IRepository<Location> _repository;

    public RemoveSocialMediaCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
