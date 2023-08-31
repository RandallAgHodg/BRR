using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Users;
using BRR.Domain.Repositories;

namespace BRR.Application.Users.Queries.RefreshToken;

public sealed class RefreshTokenQueryHandler : IQueryHandler<RefreshTokenQuery, AuthResponse>
{
    private readonly IUserInformationProvider _userInformationProvider;
    private readonly IJWTProvider _jwtProvider;
    private readonly IUserRepository _userRepository;
    public RefreshTokenQueryHandler(IUserInformationProvider userInformationProvider, IJWTProvider jwtProvider, IUserRepository userRepository)
    {
        _userInformationProvider = userInformationProvider;
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
    }

    public async Task<AuthResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var loggedUserId = _userInformationProvider.UserId;

        if (loggedUserId is 0)
            throw new CouldntRetrieveLoggedUserInformationException(
                "No se pudo recuperar la informacion del usuario con sesion inciada. Intentelo nuevamente");
        
        var user = await _userRepository.FindByIdAsync(loggedUserId);

        if (user is null)
            throw new UserNotFoundException(
                "La informacion del usuario con sesion iniciada no pudo ser recuperada. Intentelo nuevamente.");

        var token = _jwtProvider.Create(user);

        return new AuthResponse(token, user.ToUserResponse());
    }

}
