using MediatR;
using RentACar.Application.Features.Mediator.Commands.ServiceCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Services.Mediator.Handlers.ServiceHandlers;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public UpdateServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.ServiceID);
        values.Title = request.Title;
        values.Description = request.Description;
        values.IconUrl = request.IconUrl;
        await _repository.UpdateAsync(values);
    }
}