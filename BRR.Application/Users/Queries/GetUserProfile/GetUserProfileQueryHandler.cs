using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Users;
using BRR.Domain.Entities;
using BRR.Domain.Repositories;

namespace BRR.Application.Users.Queries.GetUserProfile;

public sealed class GetUserProfileQueryHandler : IQueryHandler<GetUserProfileQuery, UserWithClientsResponse>
{
    private readonly IUserInformationProvider _userInformationProvider;
    private readonly IUserRepository _userRepository;

    public GetUserProfileQueryHandler(IUserInformationProvider userInformationProvider, IUserRepository userRepository)
    {
        _userInformationProvider = userInformationProvider;
        _userRepository = userRepository;
    }

    public async Task<UserWithClientsResponse> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var userId = _userInformationProvider.UserId;

        if (userId is 0) 
            throw new UserNotFoundException(
                "No se pudo recuperar la informacion del usuario registrado");
        
        var user = await _userRepository.FindByIdAsync(userId);

        IEnumerable<AppUser> clients = Enumerable.Empty<AppUser>();
        
        if(user.IsAgent)
            clients = await _userRepository.GetAgentClientsAsync(userId);
        
        user.SetClients(clients);
        

        if (user is null)
            throw new UserNotFoundException(
                "La informacion del usuario no pudo ser recuperada con exito. Intentelo nuevamente.");

        var response = user.ToUserWithClientsResponse();

        return response;
    }
}
