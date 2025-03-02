using MediatR;
using RentACar.Application.Features.Mediator.Queries.AppUserQueries;
using RentACar.Application.Features.Mediator.Results.AppUserResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var value = new GetCheckAppUserQueryResult();
            var user  = await _appUserRepository.GetByFilterAsync(x=>x.UserName == request.Username && x.Password == request.Password);
            
            if (user is null) value.isExist = false;
            else
            {
                value.isExist = true;
                value.Username = user.UserName;
                value.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleID == user.AppRoleId))?.AppRoleName;
                value.Id = user.AppUserID;
            }
            return value;
        }
    }
}
