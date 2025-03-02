using MediatR;
using RentACar.Application.Features.Mediator.Commands.PricingCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Pricings.Mediator.Handlers.PricingHandlers;

public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
{
    private readonly IRepository<Pricing> _repository;

    public UpdatePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.PricingID);
        values.Name = request.Name;
        await _repository.UpdateAsync(values);
    }
}