using MediatR;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarIdCommandHandler : IRequestHandler<CreateCarFeatureByCarIdCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateCarFeatureByCarIdCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureByCarIdCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureRepository.CreateCarFeatureByCarIdAsync(new CarFeature
            {
                Available = false,
                CarID = request.CarID,
                FeatureID = request.FeatureID,
            });
        }
    }
}
