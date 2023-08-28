using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Users;
using BRR.Domain.Repositories;

namespace BRR.Application.Users.Queries.GetUserById;

public sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserReponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository) =>
        _userRepository = userRepository;
    

    public async Task<UserReponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id);

        return user is not null ? user.ToUserResponse() :
            throw new UserNotFoundException($"El usuario con id ${request.Id} no pudo ser encontrado");
    }
}
