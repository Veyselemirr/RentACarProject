using MediatR;
using RentACar.Application.Features.Mediator.Commands.ServiceCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Services.Mediator.Handlers.ServiceHandlers;

public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>

{
    private readonly IRepository<Service> _repository;

    public RemoveServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
