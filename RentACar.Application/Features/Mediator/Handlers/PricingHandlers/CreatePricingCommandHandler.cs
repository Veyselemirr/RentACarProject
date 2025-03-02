using MediatR;
using RentACar.Application.Features.Mediator.Commands.PricingCommands;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Pricings.Mediator.Handlers.PricingHandlers;

public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
{
    private readonly IRepository<Pricing> _repository;

    public CreatePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Pricing
        {
            Name = request.Name,
        });
    }
}
