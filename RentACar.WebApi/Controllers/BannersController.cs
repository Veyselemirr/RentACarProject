using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACar.Application.Features.CQRS.Queries.AboutQueries;

namespace RentACar.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BannersController : ControllerBase
{
    private readonly GetBannerQueryHandler _getBannerQueryHandler;
    private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
    private readonly CreateBannerCommandHandler _createBannerCommandHandler;
    private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
    private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

    public BannersController(GetBannerQueryHandler getBannerQueryHandler,
        GetBannerByIdQueryHandler getBannerByIdQueryHandler,
        CreateBannerCommandHandler createBannerCommandHandler,
        UpdateBannerCommandHandler updateBannerCommandHandler,
        RemoveBannerCommandHandler removeBannerCommandHandler)
    {
        _getBannerQueryHandler = getBannerQueryHandler;
        _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        _createBannerCommandHandler = createBannerCommandHandler;
        _updateBannerCommandHandler = updateBannerCommandHandler;
        _removeBannerCommandHandler = removeBannerCommandHandler;
    }
    [HttpGet]
    public async Task<IActionResult> BannerList()
    {
        var values = await _getBannerQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBanner(int id)
    {
        var values = await _getBannerByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
    {
        await _createBannerCommandHandler.Handle(command);
        return Ok("Bilgi Eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveBanner(RemoveBannerCommand command)
    {
        await _removeBannerCommandHandler.Handle(command);
        return Ok("Bilgi Silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateeBanner(UpdateBannerCommand command)
    {
        await _updateBannerCommandHandler.Handle(command);
        return Ok("Bilgi Güncellendi");
    }


}
