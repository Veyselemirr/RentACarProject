using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarDescriptionQueries;
using RentACar.Application.Features.Mediator.Results.CarDescriptionResults;
using RentACar.Application.Interfaces.CarDescriptionInterfaces;

namespace RentACar.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _carDescriptionRepository.GetCarDescriptionByCarIdAsync(request.Id);
            return new GetCarDescriptionByCarIdQueryResult
            {
                CarDescriptionID = values.CarDescriptionID,
                CarID = values.CarID,
                Details = values.Details
            };
        }
    }
}
