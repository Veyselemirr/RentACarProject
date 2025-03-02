using RentACar.Application.Features.CQRS.Queries.AboutQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces;
using RentACarDomain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerByIdQueryHandler
{
    private readonly IRepository<Banner> _repository;

    public GetBannerByIdQueryHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }
    public async Task<GetBannerByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetBannerByIdQueryResult
        {
            BannerID = values.BannerID,
            Description = values.Description,
            Title = values.Title,
          
        };
    }
}
