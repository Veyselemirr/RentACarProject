using MediatR;
using OnionCarBook.Application.Features.Mediator.Commands.RegisterAppUserCommands;
using RentACar.Application.Enums;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;

namespace RentACarDomain.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                UserName = request.UserName,
                Password = request.Password,
                AppRoleId = (int)RoleTypes.Member,
                Email = request.Email,
                FirstName = request.FirstName,
                SurName = request.SurName
            });
        }
    }
}
