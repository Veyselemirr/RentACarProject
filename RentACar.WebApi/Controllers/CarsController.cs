using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers;
using RentACar.Application.Features.CQRS.Queries.CarQueries;

namespace RentACar.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CreateCarCommandHandler _createCarCommandHandler;
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly UpdateCarCommandHandler _updateCarCommandHandler;
    private readonly RemoveCarCommandHandler _removeCarCommandHandler;
    private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
    private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsCarWithBrandQueryHandler;


    public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetLast5CarsWithBrandQueryHandler getLast5CarsCarWithBrandQueryHandler)
    {
        _createCarCommandHandler = createCarCommandHandler;
        _getCarByIdQueryHandler = getCarByIdQueryHandler;
        _getCarQueryHandler = getCarQueryHandler;
        _updateCarCommandHandler = updateCarCommandHandler;
        _removeCarCommandHandler = removeCarCommandHandler;
        _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        _getLast5CarsCarWithBrandQueryHandler = getLast5CarsCarWithBrandQueryHandler;
    }
    [HttpGet]
    public async Task<IActionResult> CarList()
    {
        var values = await _getCarQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
        var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    { 
        await _createCarCommandHandler.Handle(command);
        return Ok("Araç Bilgisi Eklendi");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCar(int id)
    {
        await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
        return Ok("Araç bilgisi silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarCommandHandler.Handle(command);
        return Ok("Araç bilgisi güncellendi");
    }
    [HttpGet("GetCarWithBrand")]
    public IActionResult GetCarWithBrand()
    {
        var values = _getCarWithBrandQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("GetLast5CarsWithBrandQueryHandler")]
    public IActionResult GetLast5CarsWithBrandQueryHandler()
    {
        var values = _getLast5CarsCarWithBrandQueryHandler.Handle();
        return Ok(values);
    }
 


}
