using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Application.Users.Commands.AddClient;
using BRR.Contracts.Responses.Users;
using BRR.Domain.Repositories;
using BRR.Domain.UOW;

namespace BRR.Application.Users.Commands.RegisterClient;

public sealed class RegisterClientCommandHandler : ICommandHandler<RegisterClientCommand, UserReponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserInformationProvider _userInformationProvider;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterClientCommandHandler(IUserRepository userRepository, IUserInformationProvider userInformationProvider, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _userInformationProvider = userInformationProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserReponse> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
    {
        var loggedUserId = _userInformationProvider.UserId;

        var client = await _userRepository.FindByIdAsync(request.clientId);

        if (client is null)
            throw new UserNotFoundException("El cliente no pudo ser encontrado. Intentelo nuevamente.");

        var agent = await _userRepository.FindByIdAsync(loggedUserId);

        if (agent is null)
            throw new UserNotFoundException("La informacion del agente no pudo ser recuperada de manera exitosa. Intentelo nuevamente.");

        agent.AddClient(client);

        client.SetAgent(agent);

        await _unitOfWork.SaveChangesAsync();
        
        var response = client.ToUserResponse();

        return response;
    }
}
