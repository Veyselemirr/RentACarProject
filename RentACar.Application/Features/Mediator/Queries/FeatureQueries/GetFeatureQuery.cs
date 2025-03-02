using MediatR;
using RentACar.Application.Features.Mediator.Results.FeatureResults;

namespace RentACar.Application.Features.Mediator.Queries.FeatureQueries;

public class GetFeatureQuery:IRequest<List<GetFeatureQueryResult>>
{
}
