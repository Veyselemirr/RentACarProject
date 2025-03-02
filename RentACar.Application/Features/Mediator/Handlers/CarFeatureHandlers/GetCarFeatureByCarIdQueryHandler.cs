using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarFeatureQueries;
using RentACar.Application.Features.Mediator.Results.CarFeatureResults;
using RentACar.Application.Interfaces.CarFeatureInterfaces;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _carFeatureRepository.GetCarFeaturesByCarIdAsync(request.Id);
            return values.Select(x=> new GetCarFeatureByCarIdQueryResult
            {
                CarID = request.Id,
                Available = x.Available,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName=x.Feature.Name
            }).ToList();
        }
    }
}
