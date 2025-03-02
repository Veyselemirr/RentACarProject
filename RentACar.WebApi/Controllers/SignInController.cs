using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.AppUserQueries;
using RentACar.Application.Tools;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SignInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(GetCheckAppUserQuery query)
        {
            var values = await _mediator.Send(query);
            if (values.isExist) return Created("", JwtGenerator.GenerateToken(values));
            return BadRequest("Kullanıcı adı veya şifresi hatalıdır");
        }
    }
}
