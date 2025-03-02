using MediatR;
using RentACar.Application.Features.Mediator.Commands.ServiceCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Services.Mediator.Handlers.ServiceHandlers;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public CreateServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Service
        {
            Description = request.Description,
            IconUrl = request.IconUrl,
            Title = request.Title,
        });
    }
}
